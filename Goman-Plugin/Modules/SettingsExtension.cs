using System;
using System.IO;
using System.Threading.Tasks;
using Goman_Plugin.Model;
using Newtonsoft.Json;

namespace Goman_Plugin.Modules
{
    public static class SettingExtension
    {
        public static async Task<MethodResult> Save(this ISettings settings, string awesomeName)
        {
            if (!Directory.Exists(settings.PluginSettingsBaseDirectory))
                Directory.CreateDirectory(settings.PluginSettingsBaseDirectory);

            var methodResult = new MethodResult {MethodName = "SettingExtension.Save"};
            ;
            try
            {
                var content = JsonConvert.SerializeObject(settings, Formatting.Indented);
                methodResult.Success =
                    await SaveFileContent($"{settings.PluginSettingsBaseDirectory}/{awesomeName}.json", content);
            }
            catch (Exception e)
            {
                methodResult.Error = e;
                methodResult.Success = false;
            }

            return methodResult;
        }

        public static async Task<MethodResult<BaseSettings>> Load(this ISettings settings, string moduleName)
        {
            var methodResult = new MethodResult<BaseSettings> {MethodName = "SettingExtension.Load"};
            ;
            try
            {
                var content = await GetFileContent($"{settings.PluginSettingsBaseDirectory}/{moduleName}.json");
                var loadedSettings = JsonConvert.DeserializeObject<BaseSettings>(content);
                settings.Enabled = loadedSettings.Enabled;
            }
            catch (Exception e)
            {
                methodResult.Error = e;
                methodResult.Success = false;
            }

            return methodResult;
        }

        public static async Task<MethodResult> Load<T>(this ISettings<T > settings, string moduleName) where T : new()
        {
            var methodResult = new MethodResult {MethodName = "SettingExtension.Load<T>"};
            try
            {
                var content = await GetFileContent($"{settings.PluginSettingsBaseDirectory}/{moduleName}.json");
                var loadedSettings = JsonConvert.DeserializeObject<BaseSettings<T>>(content);
                settings.Extra = (loadedSettings.Extra != null) ? loadedSettings.Extra : new T();
                settings.Enabled = loadedSettings.Enabled;
                methodResult.Success = true;
            }
            catch (Exception e)
            {
                methodResult.Error = e;
                methodResult.Success = false;
            }

            return methodResult;
        }

        private static async Task<string> GetFileContent(string path)
        {
            string content;
            using (var sr = new StreamReader(path))
            {
                content = await sr.ReadToEndAsync();
            }

            return content;
        }

        private static async Task<bool> SaveFileContent(string path, string content)
        {
            using (var sw = new StreamWriter(path, false))
            {
                await sw.WriteLineAsync(content);
            }

            return true;
        }
    }
}