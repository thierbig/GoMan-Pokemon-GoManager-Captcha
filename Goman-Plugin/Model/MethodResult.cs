using System;

namespace Goman_Plugin.Model
{
    public class MethodResult
    {
        public bool Success { get; set; }
        public Exception Error { get; set; }
        public string MethodName { get; set; }
    }

    public class MethodResult<T> : MethodResult
    {
        public T Data { get; set; }
        
    }
}
