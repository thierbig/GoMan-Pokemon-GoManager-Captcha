using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoManPTCAccountCreator.Controller;
using GoManPTCAccountCreator.Interfaces;

namespace GoManPTCAccountCreator.QueuedTasks
{
   public class QueuedTaskSaveAccountInformation : BaseQueuedTask
    {
        private static readonly StreamWriter _exportStreamWriter = new StreamWriter("AccountInformation.txt", true);

        public QueuedTaskSaveAccountInformation(IAccountManager accountManager, IQueuedTask nextQueuedTask)
            : base(accountManager, nextQueuedTask)
        {
            MaxFailures = 20;
        }


        protected override async Task<QueuedTaskResult> HiddenRun()
        {
            var queuedResult = new QueuedTaskResult();
            try
            {
                await _exportStreamWriter.WriteLineAsync($"{Value.Account.Username}:{Value.Account.Password}");
                await _exportStreamWriter.FlushAsync();
                queuedResult.Success = true;
            }
            catch (Exception e)
            {
                queuedResult.Error = e;
                queuedResult.Success = false;
            }

            return queuedResult;
        }
    }
}
