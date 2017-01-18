using System;
using Newtonsoft.Json;

namespace GoManCaptcha
{
    class VersionModel
    {
        [JsonIgnore]
        public static readonly string CurrentVersion = "1.7";
        [JsonIgnore]
        public static readonly string SavePath = "./Plugins/GoMan-Pokemon-GoManager-Captcha.dll";
        [JsonIgnore]
        public static readonly Uri Uri = new Uri("http://bit.ly/2k3b0PF");
        public string Version { get; set; }
        public string UpdateUrl { get; set; }
    }
}
