using System.Threading.Tasks;
using Goman_Plugin.Model;
using Goman_Plugin.Module.Captcha;
using Goman_Plugin.Wrapper;
using GoPlugin;
using GoPlugin.Enums;
using GoPlugin.Events;
using MethodResult = Goman_Plugin.Model.MethodResult;

namespace Goman_Plugin.Modules.Captcha
{
    public class CaptchaModule : AbstractModule
    {
        public CaptchaModule()
        {
            Settings = new BaseSettings<CaptchaSettings> { Enabled = true };
        }
        public new BaseSettings<CaptchaSettings> Settings { get; }
        public override async Task<MethodResult> Enable(bool forceSubscribe = false)
        {
            var loadSettingsResult = await LoadSettings();

            if (!loadSettingsResult.Success)
            {
                Settings.Extra = new CaptchaSettings();
                await SaveSettings();
            }

            if (Settings.Enabled)
            {
                if (forceSubscribe)
                {
                    foreach (var account in Plugin.Accounts)
                    {
                        PluginOnManagerAdded(this, account);
                    }
                }
                Plugin.ManagerAdded += PluginOnManagerAdded;
                Plugin.ManagerRemoved += PluginOnManagerRemoved;
                OnModuleEvent(this, Modules.ModuleEvent.Enabled);
            }
            return new MethodResult { Success = Settings.Enabled };
        }
        public override async Task<MethodResult> Disable(bool forceUnsubscribe = false)
        {
            Plugin.ManagerAdded -= PluginOnManagerAdded;
            Plugin.ManagerRemoved -= PluginOnManagerRemoved;
            await Settings.Save(ModuleName);

            if (forceUnsubscribe)
            {
                foreach (var account in Plugin.Accounts)
                {
                    PluginOnManagerRemoved(this, account);
                }
            }

            OnModuleEvent(this, Modules.ModuleEvent.Disabled);
            return new MethodResult { Success = true };
        }
        private async Task<MethodResult> LoadSettings()
        {
            var loadSettingsResult = await Settings.Load(ModuleName);
            loadSettingsResult.MethodName = "LoadSettings";
            OnLogEvent(this, GetLog(loadSettingsResult));
            return loadSettingsResult;
        }
        private async Task<MethodResult> SaveSettings()
        {
            var saveSettingsResult = await Settings.Save(ModuleName);
            saveSettingsResult.MethodName = "SaveSettings";
            OnLogEvent(this, GetLog(saveSettingsResult));
            return saveSettingsResult;
        }
        private void PluginOnManagerAdded(object o, Manager manager)
        {
           // OnLogEvent(this, new LogModel(LoggerTypes.Info, $"Subscribing to account {manager.Bot.AccountName}"));
            manager.OnCaptchaEvent += OnCaptcha;
        }
        private void PluginOnManagerRemoved(object o, Manager manager)
        {
            //OnLogEvent(this, new LogModel(LoggerTypes.Info, $"Unsubscribing to account {manager.Bot.AccountName}"));
            manager.OnCaptchaEvent -= OnCaptcha;
        }
        public async Task StoppedSolveCaptcha(Manager manager)
        {
            if (manager.SolvingCaptcha) return;

            await manager.Bot.Login();
            manager.Bot.LoginWait();
            await Task.Delay(5000);

        }
        private async void OnCaptcha(object sender, CaptchaRequiredEventArgs captchaRequiredEventArgs)
        {
            var managerWrapper = (Manager)sender;
            var manager = managerWrapper.Bot;

            if (!Plugin.CaptchaModule.Settings.Enabled)
            {
                OnLogEvent(this, new LogModel(LoggerTypes.Warning, "Captcha Module is disabled, stopping account"), manager);
                manager.Stop();
                return;
            }

            if (manager.AccountState == AccountState.CaptchaRequired && manager.State == BotState.Stopped)
            {
                await StoppedSolveCaptcha(managerWrapper);
                return;
            }

            if (managerWrapper.SolvingCaptcha || !manager.CaptchaRequired && !string.IsNullOrEmpty(manager.CaptchaURL)) return;
            OnLogEvent(this, new LogModel(LoggerTypes.Info, $"Solving captcha at URL: {manager.CaptchaURL}"), manager);

            managerWrapper.SolvingCaptcha = true;
            var results = await CaptchaHandler.Handle(managerWrapper);

            OnLogEvent(this, GetLog(results), manager);
            if (!results.Success) manager.Stop();
            managerWrapper.SolvingCaptcha = false;
        }
    }
}