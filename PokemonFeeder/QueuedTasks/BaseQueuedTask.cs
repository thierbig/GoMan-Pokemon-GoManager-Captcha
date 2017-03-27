using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoManPTCAccountCreator.Interfaces;
using GoManPTCAccountCreator.Model;

namespace GoManPTCAccountCreator.QueuedTasks
{ 
    public abstract class BaseQueuedTask : IQueuedTask<IAccountManager>
    {
        public IAccountManager Value { get; }
        public IQueuedTask NextQueuedTask { get; }
        public static HashSet<string> NonRecoverableErrors { get; } = new HashSet<string>()
            {
                "Account Already Exists",
                "ERROR_KEY_DOES_NOT_EXIST",
                "ERROR_ZERO_BALANCE",
                "Unknown Error"
            };
        public int MaxFailures { get; set; }
        public int CurrentFailures { get; set; }
        protected abstract Task<QueuedTaskResult> HiddenRun();

        protected BaseQueuedTask(IAccountManager accountManager, IQueuedTask nextQueuedTask)
        {
            Value = accountManager;
            NextQueuedTask = nextQueuedTask;
            MaxFailures = 5;
        }
        public async Task<QueuedTaskResult> Run()
        {

            AccountManagerStats.DecreaseCount(this.Value.AccountStatus);
            AccountManagerStats.IncreaseCount(AccountStatus.Running);

            this.Value.AccountStatus = AccountStatus.Running;
            this.Value.CurrentTask = GetType().Name;
            Value.Logs.Add(new LogModel(LoggerTypes.Debug, $"{GetType().Name}: Starting", ""));

           var queuedResult = await this.HiddenRun();

            var message = queuedResult.Success ? "Success" : queuedResult?.Error?.Message;
            queuedResult.Message = $"{GetType().Name}: {message}";

            Value.Logs.Add(queuedResult.Success
                ? new LogModel(LoggerTypes.Success, queuedResult.Message, "")
                : new LogModel(LoggerTypes.Exception, queuedResult.Message, queuedResult.Value, queuedResult.Error));


            HandleTaskResults(queuedResult);
            return queuedResult;
        }

        public Status IsReady
        {
            get
            {
                if (this.Value.HttpInformation.GoProxy == null)
                    this.Value.HttpInformation.ChangeProxy();

                if (MaxFailures <= CurrentFailures)
                    return Status.Failed;

                return this.Value.HttpInformation.GoProxy  ==  null ? Status.NotReady : Status.Ready;
            }
        }

        public void HandleTaskResults(QueuedTaskResult result)
        {
            AccountManagerStats.DecreaseCount(this.Value.AccountStatus);

            if (result.Success && NextQueuedTask == null)
            {
                AccountManagerStats.IncreaseCount(AccountStatus.Created);
                this.Value.AccountStatus = AccountStatus.Created;
                return;
            }

            if (!IsRecoverableError(result))
            {
                CurrentFailures = MaxFailures + 1;
                AccountManagerStats.IncreaseCount(AccountStatus.Failed);
                this.Value.AccountStatus = AccountStatus.Failed;
                return;
            }

            AccountManagerStats.IncreaseCount(AccountStatus.Pending);
            this.Value.AccountStatus = AccountStatus.Pending;
            if (result.Error != null && result.Error.Message.Equals("Rate Limit Exceeded"))
            {
                ProxyHandlerSingleton.Instance.MarkOnCoolDown(Value.HttpInformation.GoProxy, true);
                this.Value.HttpInformation.ChangeProxy();
                return;
            }

            if (result.Error == null) return;
            ProxyHandlerSingleton.Instance.IncreaseFailCounter(this.Value.HttpInformation.GoProxy);
            CurrentFailures++;
        }

        public virtual bool IsRecoverableError(QueuedTaskResult result)
        {
            if (result.Error == null) return true;
            return !NonRecoverableErrors.Any(r => result.Error.Message.Equals(r));
        }

        public void Dispose()
        {
            this.Value.HttpInformation.Dispose();
        }
    }
}
