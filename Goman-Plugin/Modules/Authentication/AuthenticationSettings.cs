using Newtonsoft.Json;

namespace Goman_Plugin.Modules.Authentication
{
    public class AuthenticationSettings
    {
        [JsonProperty]
        public static string Username { get; set; }
        [JsonProperty]
        public static string Password { get; set; }
        [JsonIgnore]
        public static bool LoggedIn { get; set; } = false;
        [JsonIgnore]
        public static bool FailedLogin { get; set; } = true;
        [JsonIgnore]
        public bool NonStaticLoggedIn => LoggedIn;
        [JsonIgnore]
        public bool NonStaticFailedLogin => FailedLogin;
        [JsonIgnore]
        public static string NonStaticUsername => Username;
        [JsonIgnore]
        public static string NonStaticPassword => Password;
    }
}
