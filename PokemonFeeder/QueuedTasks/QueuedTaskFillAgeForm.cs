using System.Threading.Tasks;
using GoManPTCAccountCreator.Interfaces;

namespace GoManPTCAccountCreator.QueuedTasks
{
    public class QueuedTaskFillAgeForm : BaseQueuedTask
    {
        public QueuedTaskFillAgeForm(IAccountManager accountManager, IQueuedTask nextQueuedTask) : base(accountManager, nextQueuedTask)
        { }


        protected override async Task<QueuedTaskResult> HiddenRun()
        {
            var queuedResult = await Tasks.AgeVerifyTask(this.Value);
            return queuedResult;
        }
    }
}
