using System;
using System.Threading.Tasks;
using Goman_Plugin.Model;
using Goman_Plugin.Module;
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
        protected virtual void OnLogEvent(object arg1, LogModel log)
        {
            Logs.Add(log);
            LogEvent?.Invoke(arg1, log);
        }

        protected virtual void OnModuleEvent(object arg1, ModuleEvent arg2)
        {
            ModuleEvent?.Invoke(arg1, arg2);
        }

        protected LogModel GetLog(MethodResult methodResult)
        {
            var loggerType = methodResult.Success ? LoggerTypes.Success : LoggerTypes.Exception;
            var newLog = new LogModel(loggerType, methodResult.MethodName, methodResult.Error);
            return newLog;
        }

        public string ModuleName { get; }
        public BaseSettings Settings { get; set; }
        public event Action<object, ModuleEvent> ModuleEvent;
        public event Action<object, LogModel> LogEvent;
        public ConcurrentHashSet<LogModel> Logs { get; } = new ConcurrentHashSet<LogModel>();
        public abstract Task<MethodResult> Enable();
        public abstract Task<MethodResult> Disable();
    }
}
