using System.Threading.Tasks;
using GoManPTCAccountCreator.Interfaces;

namespace GoManPTCAccountCreator.QueuedTasks
{
    public class QueuedTaskFillProfileForm : BaseQueuedTask
    {
        public QueuedTaskFillProfileForm(IAccountManager accountManager, IQueuedTask nextQueuedTask) : base(accountManager, nextQueuedTask)
        { }


        protected override async Task<QueuedTaskResult> HiddenRun()
        {
            var queuedResult = await Tasks.StartSolveCaptchaTask(this.Value);
            if (!queuedResult.Success) return queuedResult;

            queuedResult = await Tasks.GetSolvedCaptchaTask(this.Value);
            if (!queuedResult.Success) return queuedResult;

            queuedResult = await Tasks.ProfileSettingsTask(this.Value);
            return queuedResult;
        }
    }
}
