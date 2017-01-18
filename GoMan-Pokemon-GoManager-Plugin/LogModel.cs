using System;
using GoPlugin;

namespace GoManCaptcha
{


        public class LogModel : Log
        {

            public LogModel(LoggerTypes loggerType, string message, Exception ex = null) : base(loggerType, message, ex)
            {
            }

            public override string ToString()
            {
                return Message;
            }
        }
}
