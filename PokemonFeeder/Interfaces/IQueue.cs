using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace GoManPTCAccountCreator.Interfaces
{
    public interface IQueue
    {
        int Count { get; }
        AutoResetEvent Notify { get; }
        ConcurrentQueue<IQueuedTask> ToDo { get; }
        HashSet<IQueuedTask> ToRemove { get; }
        void Add(IQueuedTask task);
        void Remove(IQueuedTask task);
        void Start();
        void Stop();
    }
}