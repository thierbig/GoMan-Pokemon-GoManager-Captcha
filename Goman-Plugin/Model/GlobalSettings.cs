namespace Goman_Plugin.Model
{
    class GlobalSettings
    {
        public bool SaveLogs { get; set; } = true;
        public bool AutoUpdate { get; set; } = true;
        public bool ToastNotifications { get; set; } = false;
        public int MaximumLogs { get; set; } = 200;

    }
}
