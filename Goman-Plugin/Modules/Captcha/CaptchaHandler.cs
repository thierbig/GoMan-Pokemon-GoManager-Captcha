using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goman_Plugin.Model;
using Goman_Plugin.Wrapper;
using GoMan.Captcha;
using GoPlugin;
using GoPlugin.Enums;
using MethodResult = GoPlugin.MethodResult;

namespace Goman_Plugin.Modules.Captcha
{
    class CaptchaHandler
    {
        private static readonly Func<string, string, IManager, Task<MethodResult>> SolveCaptchaAction = async (captchaKey, captchaUrl, manager) => await SolveCaptcha(captchaKey, captchaUrl, manager);
        private static readonly HashSet<string> CaptchaExceptions = new HashSet<string>()
        {
            "ERROR: 1001",
            "ERROR: 1002",
            "ERROR: 1003",
            "ERROR: 1004",
            "ERROR: 1005",
            "ERROR_WRONG_USER_KEY",
            "ERROR_KEY_DOES_NOT_EXIST",
            "ERROR_ZERO_BALANCE",
            "ERROR_NO_SLOT_AVAILABLE",
            "ERROR_ZERO_CAPTCHA_FILESIZE",
            "ERROR_TOO_BIG_CAPTCHA_FILESIZE",
            "ERROR_WRONG_FILE_EXTENSION",
            "ERROR_IMAGE_TYPE_NOT_SUPPORTED",
            "ERROR_IP_NOT_ALLOWED",
            "IP_BANNED",
            "ERROR_CAPTCHAIMAGE_BLOCKED",
        };

        public static async Task<MethodResult> Handle(Manager managerHandler)
        {
            var manager = managerHandler.Bot;

            managerHandler.AddLog(LoggerTypes.Info, $"Solving captcha at URL: {manager.CaptchaURL}");

            while (manager.State == BotState.Pausing)
                await Task.Delay(250);

            var solveCaptchaRetryActionResults = await RetryAction(
                SolveCaptchaAction,
                ApplicationModel.Settings.CaptchaKey,
                manager.CaptchaURL,
                manager, ApplicationModel.Settings.SolveAttemptsBeforeStop);

            if (!solveCaptchaRetryActionResults.Success)
            {
                var captchaError = CaptchaExceptions.Any(x => x.Contains(x));
                if (captchaError)
                {
                    ApplicationModel.Settings.Enabled = false;
                    solveCaptchaRetryActionResults.Message = $"2Captcha {solveCaptchaRetryActionResults.Message}";
                }
            }

            managerHandler.AddLog(solveCaptchaRetryActionResults.Success ? LoggerTypes.Success : LoggerTypes.Exception, $"{solveCaptchaRetryActionResults.Message}");

            return solveCaptchaRetryActionResults;
        }

        private static async Task<MethodResult> SolveCaptcha(string captchaKey, string captchaUrl, IManager manager)
        {
            var captchaResponse = await CaptchaHttp.GetCaptchaResponse(captchaKey, captchaUrl);
            if (!captchaResponse.Success) return captchaResponse;

            return await manager.VerifyCaptcha(captchaResponse.Data);
        }

        private static async Task<MethodResult> RetryAction(Func<string, string, IManager, Task<MethodResult>> action,
            string captchaKey, string captchaUrl, IManager manager, int tryCount)
        {
            var tries = 1;
            var methodResult = new MethodResult();

            while (tries < tryCount)
            {
                methodResult = await action(captchaKey, captchaUrl, manager);

                if (!methodResult.Success)
                    tries++;

                if (methodResult.Success) break;
                await Task.Delay(1000);
            }
            return methodResult;
        }
    }
}
