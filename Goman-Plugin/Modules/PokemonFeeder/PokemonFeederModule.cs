using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Goman_Plugin.Helpers;
using Goman_Plugin.Model;
using Goman_Plugin.Wrapper;
using GoPlugin;
using GoPlugin.Events;
using Newtonsoft.Json;
using MethodResult = Goman_Plugin.Model.MethodResult;

namespace Goman_Plugin.Modules.PokemonFeeder
{
    public class PokemonFeederModule : AbstractModule
    {
        private readonly Timer _pokemonTimer;
        public HashSet<PokemonLocationInformation> PokemonDataInformation = new HashSet<PokemonLocationInformation>();

        public PokemonFeederModule()
        {
            Settings = new BaseSettings<PokemonFeederSettings> {Enabled = true};
            _pokemonTimer = new Timer();
        }

        public new BaseSettings<PokemonFeederSettings> Settings { get; }

        public async Task<MethodResult> Execute()
        {
            List<PokemonLocationInformation> copiedList;
            lock (PokemonDataInformation)
            {
                copiedList = new List<PokemonLocationInformation>(PokemonDataInformation);
                PokemonDataInformation.Clear();
            }

            var jsonString = JsonConvert.SerializeObject(copiedList);
            var result =
                await GomanHttpHelper.PokemonFeeder.SendPokemons(new StringContent(jsonString, Encoding.UTF8,
                    "application/json"));

            if (!result.Success)
                lock (PokemonDataInformation)
                {
                    copiedList.ForEach(x => PokemonDataInformation.Add(x));
                }

            result.MethodName = "Execute Uploading";
            OnLogEvent(this, GetLog(result));
            return result;
        }

        public override async Task<MethodResult> Enable(bool forceSubscribe = false)
        {
            await LoadSettings();

            if (Settings.Enabled)
            {

                if (forceSubscribe)
                {
                    foreach (var account in Plugin.Accounts)
                    {
                        PluginOnManagerAdded(this, account);
                    }
                }
                _pokemonTimer.Interval = Settings.Extra.IntervalMilliseconds;
                Plugin.ManagerAdded += PluginOnManagerAdded;
                Plugin.ManagerRemoved += PluginOnManagerRemoved;
                _pokemonTimer.Elapsed += _pokemonTimer_Elapsed;
                _pokemonTimer.Enabled = true;
                OnModuleEvent(this, Modules.ModuleEvent.Enabled);
            }

            return new MethodResult {Success = Settings.Enabled};
        }

        public override async Task<MethodResult> Disable(bool forceUnsubscribe = false)
        {
            if (!_pokemonTimer.Enabled) return new MethodResult { Success = true };
            Plugin.ManagerAdded -= PluginOnManagerAdded;
            Plugin.ManagerRemoved -= PluginOnManagerRemoved;
            _pokemonTimer.Elapsed -= _pokemonTimer_Elapsed;

            _pokemonTimer.Enabled = false;
            await SaveSettings();
            if (forceUnsubscribe)
            {
                foreach (var account in Plugin.Accounts)
                {
                    PluginOnManagerRemoved(this,account);
                }
            }
            OnModuleEvent(this, Modules.ModuleEvent.Disabled);
            return new MethodResult {Success = true};
        }
        public async Task<MethodResult> LoadSettings()
        {
            var loadSettingsResult = await Settings.Load(ModuleName);

            if (!loadSettingsResult.Success)
            {
                Settings.Extra = new PokemonFeederSettings();
                await SaveSettings();
            }

            loadSettingsResult.MethodName = "LoadSettings";
            OnLogEvent(this, GetLog(loadSettingsResult));
            return loadSettingsResult;
        }
        public async Task<MethodResult> SaveSettings()
        {
            var saveSettingsResult = await Settings.Save(ModuleName);
            saveSettingsResult.MethodName = "SaveSettings";
            OnLogEvent(this, GetLog(saveSettingsResult));
            return saveSettingsResult;
        }
        private void PluginOnManagerAdded(object o, Manager manager)
        {
           // OnLogEvent(this, new LogModel(LoggerTypes.Info, $"Subscribing to account {manager.Bot.AccountName}"));
            manager.Bot.OnPokemonEncounter += OnPokemonEncounter;
        }

        private void PluginOnManagerRemoved(object o, Manager manager)
        {
           // OnLogEvent(this, new LogModel(LoggerTypes.Info, $"Unsubscribing to account {manager.Bot.AccountName}"));
            manager.Bot.OnPokemonEncounter -= OnPokemonEncounter;
        }
        private void OnPokemonEncounter(object sender, PokemonEncounteredEventArgs e)
        {
            var manager = (IManager) sender;
            lock (PokemonDataInformation)
            {
                var iv = manager.CalculateIVPerfection(e.WildPokemon.PokemonData).Data;
                PokemonDataInformation.Add(new PokemonLocationInformation(e, iv));
                
            }
        }

        private async void _pokemonTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (PokemonDataInformation.Count == 0) return;
            var results = await Execute();
        }
    }
}