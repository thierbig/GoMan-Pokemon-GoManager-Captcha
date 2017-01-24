using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoMan.Model
{
    class ApplicationModel
    {
        private static ApplicationModel _instance;

        private ApplicationModel()
        {
        }

        public static ApplicationModel Settings
        {
            get
            {
                if (_instance == null && File.Exists("GoMan-Pokemon-GoManager-Captcha.json"))
                    _instance = LoadSetting();

                if (_instance == null)
                {
                    _instance = new ApplicationModel();
                    _instance.SaveSetting();
                }

                return _instance;
            }
        }

        public string CaptchaKey { get; set; } = "";
        public int SolveAttemptsBeforeStop { get; set; } = 5;
        public bool Enabled { get; set; } = true;
        public bool SaveLogs { get; set; } = true;
        public bool AutoUpdate { get; set; } = true;
        //public int MaxThreads { get; set; } = 15;
        public string ProxyDomain { get; set; } = "chancity.hopto.org";
        public int ProxyPort { get; set; } = 1080;
        public int CaptchaSamplingTimeMinutes = 1;
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public async Task<bool> SaveSetting()
        {
            try
            {
                string settings = JsonConvert.SerializeObject(this, Formatting.Indented);

                using (StreamWriter sw = new StreamWriter("GoMan-Pokemon-GoManager-Captcha.json", false))
                    await sw.WriteLineAsync(settings);
            }
            catch
            {
                return false;
            }

            return true;
        }
        private static ApplicationModel LoadSetting()
        {
            try
            {
                using (var sr = new StreamReader("GoMan-Pokemon-GoManager-Captcha.json"))
                {
                    return JsonConvert.DeserializeObject<ApplicationModel>(sr.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }

    }
}
