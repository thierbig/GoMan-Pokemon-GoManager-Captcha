namespace Goman_Plugin.Modules
{
    public interface ISettings
    {
        string PluginSettingsBaseDirectory { get; set; }
        bool Enabled { get; set; }
    }
    public interface ISettings<T> : ISettings
    {
        T Extra { get; set; }
    }
}
