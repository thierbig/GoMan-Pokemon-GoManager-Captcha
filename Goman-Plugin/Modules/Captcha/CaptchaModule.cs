using System;
using System.Threading.Tasks;
using Goman_Plugin.Model;
using Goman_Plugin.Module.Captcha;
using Goman_Plugin.Wrapper;
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
        public override async Task<MethodResult> Enable()
        {
            var loadSettingsResult = await LoadSettings();

            if (!loadSettingsResult.Success)
            {
                Settings.Extra = new CaptchaSettings();
                await SaveSettings();
            }

            if (Settings.Enabled)
            {

                Plugin.ManagerAdded += PluginOnManagerAdded;
                Plugin.ManagerRemoved += PluginOnManagerRemoved;
                OnModuleEvent(this, Modules.ModuleEvent.Enabled);
            }

            return new MethodResult { Success = Settings.Enabled };
        }
        public override async Task<MethodResult> Disable()
        {
            Plugin.ManagerAdded -= PluginOnManagerAdded;
            Plugin.ManagerRemoved -= PluginOnManagerRemoved;

            await Settings.Save(ModuleName);
            OnModuleEvent(this, Modules.ModuleEvent.Disabled);
            return new MethodResult { Success = true };
        }
        private void PluginOnManagerAdded(object o, Manager manager)
        {
            manager.OnCaptchaEvent += OnCaptcha;
        }
        private void PluginOnManagerRemoved(object o, Manager manager)
        {
            manager.OnCaptchaEvent -= OnCaptcha;
        }
        public async Task<MethodResult> LoadSettings()
        {
            return await Settings.Load(ModuleName);
        }
        public async Task<MethodResult> SaveSettings()
        {
            var saveSettingsResult = await Settings.Save(ModuleName);
            return saveSettingsResult;
        }
        public async void StoppedSolveCaptcha(Manager manager)
        {
            if (manager.SolvingCaptcha || !ApplicationModel.Settings.Enabled) return;

            await Task.Run(delegate
            {
                manager.Bot.Login();
                manager.Bot.LoginWait();
            });
        }
        private async void OnCaptcha(object sender, CaptchaRequiredEventArgs captchaRequiredEventArgs)
        {
            var managerWrapper = (Manager)sender;
            var manager = managerWrapper.Bot;

            if (manager.AccountState == AccountState.CaptchaRequired && manager.State == BotState.Stopped)
            {
                StoppedSolveCaptcha(managerWrapper);
                return;
            }

            if (managerWrapper.SolvingCaptcha || !manager.CaptchaRequired && !string.IsNullOrEmpty(manager.CaptchaURL)) return;

            if (!ApplicationModel.Settings.Enabled)
            {
                manager.Stop();
                return;
            }

            managerWrapper.SolvingCaptcha = true;

            var results = await CaptchaHandler.Handle(managerWrapper);

            if (!results.Success) manager.Stop();

            managerWrapper.SolvingCaptcha = false;
        }
    }
}