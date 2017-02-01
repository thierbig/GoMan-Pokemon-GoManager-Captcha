using System;
using GoPlugin;

namespace Goman_Plugin.Model
{
    public class LogModel : Log
    {
        public DateTime LogTime;

        public LogModel(LoggerTypes loggerType, string message, Exception ex = null) : base(loggerType, message, ex)
        {
            LogTime = DateTime.Now;
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
