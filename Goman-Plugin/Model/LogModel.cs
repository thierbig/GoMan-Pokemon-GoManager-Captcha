using System;
using GoPlugin;

namespace Goman_Plugin.Model
{
    public class LogModel : Log
    {

        public LogModel(LoggerTypes loggerType, string message, Exception ex = null) : base(loggerType, message, ex)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Date)}: {Date}";
        }

    }
}
