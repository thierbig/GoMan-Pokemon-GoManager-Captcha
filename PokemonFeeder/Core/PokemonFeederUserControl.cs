using System;
using System.IO;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace PokemonFeeder.Core
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

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string data = Prompt.ShowDialog("Uri", "Add", "http://somerocketmapurl");
            Uri value;

            if (!Uri.TryCreate(data, UriKind.RelativeOrAbsolute, out value)) return;

            var newRocketMapQuery = new RocketmapScraperQuery(value);

            fastObjectListViewScrapper.AddObject(newRocketMapQuery);
            Plugin.RocketmapScrapers.Add(newRocketMapQuery);
            newRocketMapQuery.Enable();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fastObjectListViewScrapper.SelectedObjects.Count == 0) return;
            var selected = (RocketmapScraperQuery) fastObjectListViewScrapper.SelectedObject;
            string data = Prompt.ShowDialog("Uri", "Edit", selected.RocketMapUri.ToString());
            Uri value;

            if (!Uri.TryCreate(data, UriKind.RelativeOrAbsolute, out value)) return;

            selected.RocketMapUri = value;

            fastObjectListViewScrapper.RefreshObject(selected);
        }

        private  void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastObjectListViewScrapper.RemoveObjects(fastObjectListViewScrapper.SelectedObjects);
            foreach (RocketmapScraperQuery rocketmapScraperQuery in fastObjectListViewScrapper.SelectedObjects)
            {
                rocketmapScraperQuery.Disable();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fastObjectListViewScrapper.RefreshObject(Plugin.RocketmapScrapers);
        }

        private void addFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var openDialog = new OpenFileDialog())
            {
                if (openDialog.ShowDialog() != DialogResult.OK) return;
                using (var sr = new StreamReader(openDialog.FileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(line)) continue;
                        Uri value;

                        if (!Uri.TryCreate(line, UriKind.RelativeOrAbsolute, out value)) continue;
                        var newRocketMapQuery = new RocketmapScraperQuery(value);

                        fastObjectListViewScrapper.AddObject(newRocketMapQuery);
                        Plugin.RocketmapScrapers.Add(newRocketMapQuery);
                        newRocketMapQuery.Enable();
                    }
                }
            }
        }
    }
}
