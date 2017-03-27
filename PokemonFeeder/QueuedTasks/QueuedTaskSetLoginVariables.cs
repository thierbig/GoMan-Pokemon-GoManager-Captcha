using System.Threading.Tasks;
using GoManPTCAccountCreator.Interfaces;

namespace GoManPTCAccountCreator.QueuedTasks
{
    public class QueuedTaskSetLoginVariables : BaseQueuedTask
    {
        public QueuedTaskSetLoginVariables(IAccountManager accountManager, IQueuedTask nextQueuedTask) : base(accountManager, nextQueuedTask)
        { }


        protected override async Task<QueuedTaskResult> HiddenRun()
        {
            var queuedResult = await Tasks.SetLoginVariablesTask(this.Value);
            return queuedResult;
        }
    }
}
