using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Goman_Plugin.Model;
using GoPlugin;
using LoggerTypes = GoPlugin.LoggerTypes;
using MethodResult = Goman_Plugin.Model.MethodResult;

namespace Goman_Plugin.Modules
{
    public enum ModuleEvent {Enabled, Disabled}
    public abstract class AbstractModule : IModule
    {
        protected AbstractModule()
        {
            ModuleName = GetType().Name;
        }
        protected async void OnLogEvent(object arg1, LogModel log, IManager manager = null)
        {
            LogEvent?.Invoke(arg1, log);
            if (!GetType().Name.Equals("AuthenticationModule"))
            {
                
                lock (Logs)
                {
                    if (Logs.Count > Plugin.GlobalSettings.Extra.MaximumLogs)
                    {
                        var topRange = Logs.Count - Plugin.GlobalSettings.Extra.MaximumLogs;
                        Logs.RemoveRange(0, topRange);
                    }

                    Logs.Add(log);
                }
            }

            await AddLog(log, manager);
        }
        public async Task AddLog(LogModel log, IManager manager = null)
        {
            if (!Plugin.GlobalSettings.Extra.SaveLogs) return;

            var error = "";
            if(log.ExceptionMessage != null && log.StackTrace != null)
                error = "\n\t" + log.ExceptionMessage + "\n\t" + log.StackTrace;

            if (manager != null)
            {
                manager.LogCallerPlugin(new LoggerEventArgs(log.Message, log.LoggerType, new Exception(log.ExceptionMessage)));
                await LogMessageToFile($"./Plugins/Goman/Logs/Accounts/", $"{manager.AccountName}.log", log.Message + error);
            }
            else
            {
                await LogMessageToFile($"./Plugins/Goman/Logs/Modules/", $"{this.ModuleName}.log", log.Message + error);
            }
        }
        private static async Task LogMessageToFile(string path, string filename, string msg)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            try
            {
                using (var sw = File.AppendText(path + filename))
                    await sw.WriteLineAsync($"{DateTime.Now:G}: {msg}.");
            }
            catch (Exception e)
            {
                //ignore
            }
        }
        protected virtual void OnModuleEvent(object arg1, ModuleEvent arg2)
        {
            IsEnabled = arg2 == Modules.ModuleEvent.Enabled;
            OnLogEvent(this, new LogModel(LoggerTypes.Info, $"{ModuleName} : {arg2}"));
            ModuleEvent?.Invoke(arg1, arg2);
        }

        protected LogModel GetLog(MethodResult methodResult)
        {
            var loggerType = methodResult.Success ? LoggerTypes.Success : LoggerTypes.Exception;
            var newLog = new LogModel(loggerType, $"{ModuleName} : {methodResult.MethodName + " " + methodResult.Message}", "", methodResult.Error);
            return newLog;
        }

        public string ModuleName { get; }
        public BaseSettings Settings { get; set; }
        public bool IsEnabled { get; set; }
        public event Action<object, ModuleEvent> ModuleEvent;
        public event Action<object, LogModel> LogEvent;
        public List<LogModel> Logs { get; } = new List<LogModel>();
        public abstract Task<MethodResult> Enable(bool forceSubscribe = false);
        public abstract Task<MethodResult> Disable(bool forceUnubscribe = false);
    }
}
