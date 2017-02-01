using Goman_Plugin.Module;
using Newtonsoft.Json;

namespace Goman_Plugin.Modules
{
    public class BaseSettings : ISettings
    {
        public bool Enabled { get; set; }
        [JsonIgnore]
        public string PluginSettingsBaseDirectory { get; set; } = "./Plugins/Goman/Settings/";
    }
    public class BaseSettings<T> : BaseSettings, ISettings<T>
    {
        public T Extra { get; set; }
    }
}
