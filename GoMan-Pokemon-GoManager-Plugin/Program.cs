using System;
using System.Globalization;
using System.Windows.Forms;

namespace GoMan
{

    static class Program
    {
        [STAThread]
        private static void Main()
        {
            // Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm(new Dictionary<IManager, ManagerHandler>()));
            //Application.Run(new LoginForm());

            MessageBox.Show(UnixTimeStampToDateTime(1487559890).ToString("yyyy-M-d HH:mm:ss", CultureInfo.InvariantCulture));
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
