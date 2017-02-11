using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Goman_Plugin.Model;
using GoPlugin;
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
            Logs.Add(log);
            await AddLog(log, manager);
            LogEvent?.Invoke(arg1, log);
        }
        public async Task AddLog(LogModel log, IManager manager = null)
        {
            if (!Plugin.GlobalSettings.Extra.SaveLogs) return;
            if (manager != null)
            {
                manager.LogCallerPlugin(new LoggerEventArgs(log));
                await LogMessageToFile($"./Plugins/Goman/Logs/Accounts/", $"{manager.AccountName}.log", log.Message);
            }
            else
            {
                await LogMessageToFile($"./Plugins/Goman/Logs/Modules/", $"{this.ModuleName}.log", log.Message);
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
            var newLog = new LogModel(loggerType, $"{ModuleName} : {methodResult.MethodName + " " + methodResult.Message}", methodResult.Error);
            return newLog;
        }

        public string ModuleName { get; }
        public BaseSettings Settings { get; set; }
        public bool IsEnabled { get; set; }
        public event Action<object, ModuleEvent> ModuleEvent;
        public event Action<object, LogModel> LogEvent;
        public ConcurrentHashSet<LogModel> Logs { get; } = new ConcurrentHashSet<LogModel>();
        public abstract Task<MethodResult> Enable(bool forceSubscribe = false);
        public abstract Task<MethodResult> Disable(bool forceUnubscribe = false);
    }
}
