using System;
using Newtonsoft.Json;

namespace GoManCaptcha
{
    class VersionModel
    {
        [JsonIgnore]
        public static readonly string CurrentVersion = "1.5";
        [JsonIgnore]
        public static readonly string SavePath = "./Plugins/GoMan-Pokemon-GoManager-Captcha.dll";
        [JsonIgnore]
        public static readonly Uri Uri = new Uri("https://raw.githubusercontent.com/chancity/GoMan-Pokemon-GoManager-Captcha/master/GoMan-Pokemon-GoManager-Captcha/version.json");
        public string Version { get; set; }
        public string UpdateUrl { get; set; }
    }
}
