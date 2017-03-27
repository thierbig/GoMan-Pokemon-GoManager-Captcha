using System.Threading.Tasks;
using GoManPTCAccountCreator.Interfaces;

namespace GoManPTCAccountCreator.QueuedTasks
{
    public class QueuedTaskCrsf : BaseQueuedTask
    {
        public QueuedTaskCrsf(IAccountManager accountManager, IQueuedTask nextQueuedTask) : base(accountManager, nextQueuedTask)
        { }


        protected override async Task<QueuedTaskResult> HiddenRun()
        {
            var queuedResult = await Tasks.GetCsrfTask(this.Value);
            return queuedResult;
        }
    }
}
