using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Goman_Plugin.Helpers;
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
            _pokemonTimer.Elapsed += _pokemonTimer_Elapsed;
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

            return result;
        }

        public override async Task<MethodResult> Enable()
        {
            var loadSettingsResult = await LoadSettings();

            if (!loadSettingsResult.Success)
            {
                Settings.Extra = new PokemonFeederSettings();
                await SaveSettings();
            }

            if (Settings.Enabled)
            {
                _pokemonTimer.Interval = Settings.Extra.IntervalMilliseconds;

                Plugin.ManagerAdded += PluginOnManagerAdded;
                Plugin.ManagerRemoved += PluginOnManagerRemoved;
                _pokemonTimer.Elapsed += _pokemonTimer_Elapsed;
                _pokemonTimer.Enabled = true;
                OnModuleEvent(this, Modules.ModuleEvent.Enabled);
            }

            return new MethodResult {Success = Settings.Enabled};
        }

        public override async Task<MethodResult> Disable()
        {
            if (!_pokemonTimer.Enabled) return new MethodResult { Success = true };
            Plugin.ManagerAdded -= PluginOnManagerAdded;
            Plugin.ManagerRemoved -= PluginOnManagerRemoved;
            _pokemonTimer.Elapsed -= _pokemonTimer_Elapsed;

            _pokemonTimer.Enabled = false;
            var saveSettingsResult = await Settings.Save(ModuleName);
            OnModuleEvent(this, Modules.ModuleEvent.Disabled);
            return new MethodResult {Success = true};
        }

        private void PluginOnManagerAdded(object o, Manager manager)
        {
            manager.Bot.OnPokemonCaught += OnPokemonCaught;
        }

        private void PluginOnManagerRemoved(object o, Manager manager)
        {
            manager.Bot.OnPokemonCaught -= OnPokemonCaught;
        }

        public async Task<MethodResult> LoadSettings()
        {
            return await Settings.Load(ModuleName);
        }

        public async Task<MethodResult> SaveSettings()
        {
            var saveSettingsResult = await Settings.Save(ModuleName);
            return saveSettingsResult;
        }

        private void OnPokemonCaught(object sender, PokemonCaughtEventArgs e)
        {
            var manager = (IManager) sender;

            lock (PokemonDataInformation)
            {
                var iv = manager.CalculateIVPerfection(e.Pokemon).Data;
                PokemonDataInformation.Add(new PokemonLocationInformation(e, iv));
            }
        }

        private async void _pokemonTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (PokemonDataInformation.Count == 0) return;
            await Execute();
        }
    }
}