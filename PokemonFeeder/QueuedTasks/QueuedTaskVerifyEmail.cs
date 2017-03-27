using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoManPTCAccountCreator.Controller;
using GoManPTCAccountCreator.Interfaces;

namespace GoManPTCAccountCreator.QueuedTasks
{
    public class QueuedTaskVerifyEmail : BaseQueuedTask
    {
        public QueuedTaskVerifyEmail(IAccountManager accountManager, IQueuedTask nextQueuedTask)
            : base(accountManager, nextQueuedTask)
        {
            MaxFailures = 100;
        }


        protected override async Task<QueuedTaskResult> HiddenRun()
        {
            await Task.Delay(3000);
            var queuedResult = await ImapController.EmailQueryAsync(this.Value.Account.Email);
            if (queuedResult.Success) this.Value.EmailVerified = true;
            return queuedResult;
        }
    }
}
