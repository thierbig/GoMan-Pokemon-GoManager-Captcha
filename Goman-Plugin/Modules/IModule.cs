using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Goman_Plugin.Model;
using MethodResult = Goman_Plugin.Model.MethodResult;

namespace Goman_Plugin.Modules
{
    public interface IModule
    {
        event Action<object, ModuleEvent> ModuleEvent;
        event Action<object, LogModel> LogEvent;
        ConcurrentHashSet<LogModel> Logs { get; }
        Task<MethodResult> Enable(bool forceSubscribe = false);
        Task<MethodResult> Disable(bool forceUnsubscribe = false);
        BaseSettings Settings { get; }
    }
}
