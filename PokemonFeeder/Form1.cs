using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokemonFeeder.Core;

namespace PokemonFeeder
{
    public partial class Plugin : Form
    {
        internal static List<RocketmapScraperQuery> RocketmapScrapers = new List<RocketmapScraperQuery>();
        public Plugin()
        {
            ServicePointManager.DefaultConnectionLimit = int.MaxValue;
            InitializeComponent();
            
        }

    }
}
