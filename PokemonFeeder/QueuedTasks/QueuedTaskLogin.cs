using System.Threading.Tasks;
using GoManPTCAccountCreator.Interfaces;

namespace GoManPTCAccountCreator.QueuedTasks
{
    public class QueuedTaskLogin : BaseQueuedTask
    {
        public QueuedTaskLogin(IAccountManager accountManager, IQueuedTask nextQueuedTask) : base(accountManager, nextQueuedTask)
        { }


        protected override async Task<QueuedTaskResult> HiddenRun()
        {
            var queuedResult = await Tasks.LoginTask(this.Value);
            return queuedResult;
        }
    }
}
