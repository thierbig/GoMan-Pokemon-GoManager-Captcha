using System.Threading.Tasks;
using GoManPTCAccountCreator.Interfaces;

namespace GoManPTCAccountCreator.QueuedTasks
{
    public class QueuedTaskSubmitTos : BaseQueuedTask
    {
        public QueuedTaskSubmitTos(IAccountManager accountManager, IQueuedTask nextQueuedTask)
            : base(accountManager, nextQueuedTask)
        {}


        protected override async Task<QueuedTaskResult> HiddenRun()
        {
            var queuedResult = await Tasks.SubmitTosTask(this.Value);
            if (queuedResult.Success) this.Value.TosAccepted = true;
            return queuedResult;
        }
    }
}