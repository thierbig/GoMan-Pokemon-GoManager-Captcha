using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoManPTCAccountCreator.Interfaces
{
    public interface IQueuedTask : IDisposable
    {
        int MaxFailures { get; set; }
        int CurrentFailures { get; set; }
        IQueuedTask NextQueuedTask { get; }
        Task<QueuedTaskResult> Run();
        QueuedTasks.Status IsReady { get; }
        void HandleTaskResults(QueuedTaskResult result);

    }

    public interface IQueuedTask<out T> : IQueuedTask
    {
        T Value { get; }
    }
}
