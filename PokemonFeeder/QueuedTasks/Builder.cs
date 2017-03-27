using GoManPTCAccountCreator.Controller;
using GoManPTCAccountCreator.Interfaces;
using GoManPTCAccountCreator.Model;

namespace GoManPTCAccountCreator.QueuedTasks
{
    public class Builder
    {
        public static IQueuedTask<IAccountManager> SignUp(IAccountManager accountManager)
        {
            if (accountManager.HttpInformation == null) accountManager.HttpInformation = new AccountHttpClient();
            var queuedTaskVerifyEmail = new QueuedTaskVerifyEmail(accountManager, null);
            var queuedTaskSaveAccountInformation = new QueuedTaskSaveAccountInformation(accountManager,queuedTaskVerifyEmail);
            var queuedTaskSubmitTos = new QueuedTaskSubmitTos(accountManager, queuedTaskSaveAccountInformation);
            var queuedTaskLogin = new QueuedTaskLogin(accountManager, queuedTaskSubmitTos);
            var queuedTaskSetLoginVariables = new QueuedTaskSetLoginVariables(accountManager, queuedTaskLogin);
            var queuedTaskFillProfileForm = new QueuedTaskFillProfileForm(accountManager, queuedTaskSetLoginVariables);
            var queuedTaskFillAgeForm = new QueuedTaskFillAgeForm(accountManager, queuedTaskFillProfileForm);
            var queuedTaskCrsf = new QueuedTaskCrsf(accountManager, queuedTaskFillAgeForm);

            return queuedTaskCrsf;
        }

        public static IQueuedTask<IAccountManager> SendVerificationEmail(IAccountManager accountManager)
        {
            if (accountManager.HttpInformation == null) accountManager.HttpInformation = new AccountHttpClient();
            var queuedTaskVerifyEmail = new QueuedTaskVerifyEmail(accountManager, null);
            var queuedTaskFillVerifyForm = new QueuedTaskFillVerifyForm(accountManager, queuedTaskVerifyEmail);
            var queuedTaskLogin = new QueuedTaskLogin(accountManager, queuedTaskFillVerifyForm);
            var queuedTaskSetLoginVariables = new QueuedTaskSetLoginVariables(accountManager, queuedTaskLogin);
            var queuedTaskCrsf = new QueuedTaskCrsf(accountManager, queuedTaskSetLoginVariables);

            return queuedTaskCrsf;
        }

        public static IQueuedTask<IAccountManager> ChangePassword(IAccountManager accountManager)
        {
            if (accountManager.HttpInformation == null) accountManager.HttpInformation = new AccountHttpClient();
            var queuedTaskFillVerifyForm = new QueuedTaskFillVerifyForm(accountManager, null);
            var queuedTaskLogin = new QueuedTaskLogin(accountManager, queuedTaskFillVerifyForm);
            var queuedTaskSetLoginVariables = new QueuedTaskSetLoginVariables(accountManager, queuedTaskLogin);
            var queuedTaskCrsf = new QueuedTaskCrsf(accountManager, queuedTaskSetLoginVariables);

            return queuedTaskCrsf;
        }
    }
}
