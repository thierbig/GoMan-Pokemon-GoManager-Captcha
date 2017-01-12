using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoPlugin;

namespace GoManCaptcha
{


        public class LogModel : LoggerEventArgs
        {

            public LogModel(LoggerTypes loggerType, string message) : base(message, loggerType)
            {
            }

            public Color GetLogColor()
            {
                switch (this.LogType)
                {
                    case LoggerTypes.Success:
                        return Color.Green;
                    case LoggerTypes.Warning:
                        return Color.Yellow;
                    case LoggerTypes.Exception:
                        return Color.Red;
                    case LoggerTypes.Debug:
                        return Color.DarkGray;
                    case LoggerTypes.Info:
                        return Color.Aquamarine;
            }

                return SystemColors.WindowText;
            }

            public override string ToString()
            {
                return Message;
            }
        }
}
