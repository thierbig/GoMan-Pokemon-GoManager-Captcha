using System;
using System.Threading.Tasks;

namespace GoManPTCAccountCreator.Interfaces
{
    public class QueuedTaskResult
    {
        public bool Success { get; set; }
        public bool Cancelled { get; set; }
        public Exception Error { get; set; }
        public string Value { get; set; }
        public string Message { get; set; }
    }
}