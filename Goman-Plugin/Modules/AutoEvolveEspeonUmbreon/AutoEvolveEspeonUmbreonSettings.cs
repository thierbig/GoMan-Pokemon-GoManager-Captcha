using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goman_Plugin.Modules.AutoEvolveEspeonUmbreon
{
    public class AutoEvolveEspeonUmbreonSettings
    {
        public int IntervalMilliseconds { get; set; } = 0;
        public AutoEvolveEspeonUmbreonSettings()
        {
            if(IntervalMilliseconds==0)
            {
                IntervalMilliseconds = 60000;
            }
        }
    }
}
