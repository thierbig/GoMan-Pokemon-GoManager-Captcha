using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoManCaptcha
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
                if (_instance != null)
                    return _instance;

                if (File.Exists("GoMan-Pokemon-GoManager-Captcha.json"))
                    _instance = LoadSetting();
                else
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
        //public int MaxThreads { get; set; } = 15;
        public string ProxyDomain { get; set; } = "chancity.hopto.org";
        public int ProxyPort { get; set; } = 1080;
        

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
            using (StreamReader sr = new StreamReader("GoMan-Pokemon-GoManager-Captcha.json"))
            {
                return JsonConvert.DeserializeObject<ApplicationModel>(sr.ReadToEnd());
            }
        }

    }
}
