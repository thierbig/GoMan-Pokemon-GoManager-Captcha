using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using GoManPTCAccountCreator.Model;
using GoManPTCAccountCreator.QueuedTasks;

namespace GoManPTCAccountCreator.Interfaces
{
    public class BaseQueue : IQueue
    {
        public int Count { get; set; }
        public AutoResetEvent Notify { get; } = new AutoResetEvent(false);
        private readonly AutoResetEvent _queueNotifier1 = new AutoResetEvent(false);
        public ConcurrentQueue<IQueuedTask> ToDo { get; } = new ConcurrentQueue<IQueuedTask>();
        public HashSet<IQueuedTask> ToRemove { get; } = new HashSet<IQueuedTask>();
        public Func<IAccount, Task<MethodResult>> Function { get; set; }

        private readonly System.Timers.Timer _timer = new System.Timers.Timer(100);

        public BaseQueue()
        {
            _timer.Elapsed += Timer_tick;
            _timer.Enabled = true;
            _timer.Start();
        }

        private bool _stopFlag;

        public void Add(IQueuedTask task)
        {
            ToDo.Enqueue(task);
            Notify.Set();
        }

        public void Remove(IQueuedTask task)
        {
            ToRemove.Add(task);
        }
        private void Timer_tick(object sender, ElapsedEventArgs e)
        {
            if (Count < ApplicationModel.Settings.MaxThreads)
                _queueNotifier1.Set();
        }
        public void Start()
        {
            _stopFlag = false;
            while (true)
            {
                Notify.WaitOne();
                while (!ToDo.IsEmpty)
                {
                    Thread.Sleep(1);
                    if (Count >= ApplicationModel.Settings.MaxThreads) _queueNotifier1.WaitOne();
                    IQueuedTask next;
                    ToDo.TryDequeue(out next);

                    if (ToRemove.Contains(next))
                    {
                        ToRemove.Remove(next);
                        continue;
                    }
                    switch (next.IsReady)
                    {
                        case Status.Ready:
                            Count++;

                            next.Run().ContinueWith(r =>
                            {
                                var queuedTaskResult = r.Result;

                                if (!queuedTaskResult.Success)
                                {
                                    Add(next);
                                }
                                else if (queuedTaskResult.Success && next.NextQueuedTask != null)
                                {
                                    Add(next.NextQueuedTask);
                                }
                                else if (next.NextQueuedTask == null)
                                {
                                    next.Dispose();
                                }

                                Count--;
                            });
                            break;
                        case Status.NotReady:
                            Add(next);
                            break;
                        case Status.Failed:
                            next.Dispose();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    if (!_stopFlag) continue;
                    break;
                }
                if (!_stopFlag) continue;
                break;
            }
        }

        public void Stop()
        {
            _stopFlag = true;
            Notify.Set();
        }
    }
}