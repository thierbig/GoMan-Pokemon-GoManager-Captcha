using System.IO;
using Newtonsoft.Json;

namespace GoManCaptcha
{
    class ApplicationModel
    {
        private static ApplicationModel _instance;

        private ApplicationModel()
        {
        }

        public static ApplicationModel Settings()
        {
            if (_instance != null)
                return _instance;
            else
            {
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

        public int MaxThreads { get; set; } = 15;
        public string ProxyDomain { get; set; } = "chancity.hopto.org";
        public int ProxyPort { get; set; } = 1080;
        public string CaptchaKey { get; set; } = "";

        public void SaveSetting()
        {
            string settings = JsonConvert.SerializeObject(this, Formatting.Indented);

            using (StreamWriter sw = new StreamWriter("GoMan-Pokemon-GoManager-Captcha.json", false))
            {
                sw.WriteLine(settings);
            }
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
