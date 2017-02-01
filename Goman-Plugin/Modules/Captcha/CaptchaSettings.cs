namespace Goman_Plugin.Module.Captcha
{
    public class CaptchaSettings
    {
        public string CaptchaKey { get; set; } = "";
        public int SolveAttemptsBeforeStop { get; set; } = 5;
        public string ProxyDomain { get; set; } = "chancity.hopto.org";
        public int ProxyPort { get; set; } = 1080;
    }
}
