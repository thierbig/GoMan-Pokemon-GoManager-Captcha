using Newtonsoft.Json;

namespace GoManCaptcha
{
    class VersionModel
    {
        [JsonIgnore]
        public static readonly string CurrentVersion = "1.0"; 
        public string Version { get; set; }
        public string UpdateUrl { get; set; }
    }
}
