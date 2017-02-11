using System;
using System.Windows.Forms;
using BrightIdeasSoftware;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GoPlugin;
using Timer = System.Timers.Timer;

namespace Goman_Plugin.Modules.AccountFeeder
{
    public partial class AccountFeederUserControl : UserControl
    {
        //private GMapOverlay pokemonMarkersOverlay;
        private GMapOverlay accountMarkersOverlay;
        private readonly Timer _accountTimer;
        public AccountFeederUserControl()
        {
            InitializeComponent();
            gMapControl1.MapProvider = GMap.NET.MapProviders.BingSatelliteMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;

            this.fastObjectListViewLogs.PrimarySortColumn = this.olvColumnDate;
            this.fastObjectListViewLogs.PrimarySortOrder = SortOrder.Descending;
            this.fastObjectListViewLogs.ListFilter = new TailFilter(200);

            accountMarkersOverlay = new GMapOverlay("accountmarkers");
            gMapControl1.Overlays.Add(accountMarkersOverlay);

            _accountTimer = new Timer();
            _accountTimer.Interval = 1000;
            _accountTimer.Elapsed += _accountTimer_Elapsed;
            _accountTimer.Enabled = true;

        }

        internal void SetControls()
        {
            cbkEnabled.Checked = Plugin.AccountFeederModule.Settings.Enabled;
            fastObjectListViewLogs.SetObjects(Plugin.AccountFeederModule.Logs);
            Plugin.AccountFeederModule.LogEvent += (o, model) => fastObjectListViewLogs.AddObject(model);
        }

        private void _accountTimer_Elapsed(object o, EventArgs e)
        {
            try
            {
                lock (accountMarkersOverlay)
                {
                    accountMarkersOverlay.Clear();
                    foreach (var account in Plugin.Accounts)
                    {
                        if (!account.Bot.IsRunning) continue;

                        GMarkerGoogle marker = new GMarkerGoogle(
                            new PointLatLng(account.Bot.CurrentLocation.Latitude, account.Bot.CurrentLocation.Longitude),
                            GMarkerGoogleType.green);

                        marker.ToolTipMode = MarkerTooltipMode.Always;
                        marker.ToolTipText = account.Bot.AccountName;
                        accountMarkersOverlay.Markers.Add(marker);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private async void cbkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Plugin.AccountFeederModule.Settings.Enabled = cbkEnabled.Checked;
            await Plugin.AccountFeederModule.Settings.Save(Plugin.AccountFeederModule.ModuleName);
            if (!Plugin.AccountFeederModule.Settings.Enabled)
                await Plugin.AccountFeederModule.Disable(true);
            else if (!Plugin.AccountFeederModule.IsEnabled)
                await Plugin.AccountFeederModule.Enable(true);
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