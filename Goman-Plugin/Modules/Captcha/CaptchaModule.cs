using System;
using System.Threading.Tasks;
using Goman_Plugin.Model;
using Goman_Plugin.Module;
using Goman_Plugin.Module.Captcha;

namespace Goman_Plugin.Modules.Captcha
{
    public class CaptchaModule : AbstractModule
    {
        public new BaseSettings<CaptchaSettings> Settings { get; }

        public Task<MethodResult> Execute()
        {
            throw new NotImplementedException();
        }

        public override Task<MethodResult> Enable()
        {
            throw new NotImplementedException();
        }

        public override Task<MethodResult> Disable()
        {
            throw new NotImplementedException();
        }

        public Task<MethodResult> LoadSettings()
        {
            throw new NotImplementedException();
        }
    }

    public class CaptchaEventArgs
    {
    }
}