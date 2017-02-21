using System;
using System.Windows.Forms;
using BrightIdeasSoftware;
using GoPlugin;

namespace Goman_Plugin.Modules.PokemonFeeder
{
    public partial class PokemonFeederUserControl : UserControl
    {
        public PokemonFeederUserControl()
        {
            InitializeComponent();

            this.fastObjectListViewLogs.PrimarySortColumn = this.olvColumnDate;
            this.fastObjectListViewLogs.PrimarySortOrder = SortOrder.Descending;
            this.fastObjectListViewLogs.ListFilter = new TailFilter(200);
        }

        internal void SetControls()
        {
            cbkEnabled.Checked = Plugin.PokemonFeederModule.Settings.Enabled;
            fastObjectListViewLogs.SetObjects(Plugin.PokemonFeederModule.Logs);
            Plugin.PokemonFeederModule.LogEvent += (o, model) => fastObjectListViewLogs.AddObject(model);
        }

        private async void cbkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Plugin.PokemonFeederModule.Settings.Enabled = cbkEnabled.Checked;
            await Plugin.PokemonFeederModule.SaveSettings();
            if (!Plugin.PokemonFeederModule.Settings.Enabled)
                await Plugin.PokemonFeederModule.Disable(true);
            else if(!Plugin.PokemonFeederModule.IsEnabled)
                await Plugin.PokemonFeederModule.Enable(true);
        }

        private void fastObjectListViewLogs_FormatCell(object sender, FormatCellEventArgs e)
        {
            Log log = e.Model as Log;
            if (log != null)
            {
                e.Item.ForeColor = log.GetLogColor();
            }
        }
    }
}
