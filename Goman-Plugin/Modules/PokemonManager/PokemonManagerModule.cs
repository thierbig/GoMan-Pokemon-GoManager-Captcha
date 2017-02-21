using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using GoPlugin;
using GoPlugin.Enums;
using POGOProtos.Data;
using MethodResult = Goman_Plugin.Model.MethodResult;
using Timer = System.Timers.Timer;

namespace Goman_Plugin.Modules.PokemonManager
{
    public class PokemonManagerModule : AbstractModule
    {
        public new BaseSettings<PokemonManagerSettings> Settings { get; }
        private static Timer _taskTimer;
        private Plugin _plugin;

        public PokemonManagerModule(Plugin plugin)
        {
            _plugin = plugin;
            Settings = new BaseSettings<PokemonManagerSettings>() {Enabled = true};
            _taskTimer = new Timer();
            _taskTimer.Elapsed += _taskTimer_Elapsed;
        }

        private void _taskTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Execute();
        }

        public void Execute()
        {
            foreach (var imanager in _plugin.GetUniqueManagers())
            {
                if (imanager.State != BotState.Running) continue;


                var pokesToFavorite = new List<PokemonData>();
                var pokesToUpgrade = new List<PokemonData>();
                var pokesToEvolve = new List<PokemonData>();
                var pokemonToHandle = GetPokemonToHandle(imanager);


                foreach (var pokemonData in pokemonToHandle)
                {
                    var pokeSetting = Settings.Extra.Pokemons[pokemonData.PokemonId];
                    var pokemonSettings = imanager.GetPokemonSetting(pokemonData.PokemonId).Data;

                    var totalCandy =
                        imanager.PokemonCandy.Where(x => x.FamilyId == pokemonSettings.FamilyId)
                            .ElementAt(0)
                            .Candy_;

                    var candyToEvolve = pokemonSettings.CandyToEvolve;


                    if (pokeSetting.AutoEvolve && candyToEvolve > 0 && totalCandy >= candyToEvolve)
                    {
                        pokesToEvolve.Add(pokemonData);
                    }
                    else
                    {
                        if (pokeSetting.AutoFavorite && pokemonData.Favorite == 0)
                            pokesToFavorite.Add(pokemonData);

                        if (pokeSetting.AutoUpgrade && totalCandy > 3)
                            pokesToUpgrade.Add(pokemonData);
                    }
                }

                EvolvePokemon(imanager, pokesToEvolve);
                UpgradePokemon(imanager, pokesToUpgrade);
                SetFavorites(imanager, pokesToFavorite);
            }
        }

        public List<PokemonData> GetPokemonToHandle(IManager manager)
        {
            var pokemonToHandle = new List<PokemonData>();

            foreach (var pokemonManager in Settings.Extra.Pokemons.Values)
            {
                pokemonToHandle
                    .AddRange(manager.Pokemon
                        .Where(
                            poke =>
                                manager.CalculateIVPerfection(poke).Data >= pokemonManager.MinimumIv &&
                                poke.Cp >= pokemonManager.MinimumCp &&
                                (pokemonManager.AutoEvolve || pokemonManager.AutoFavorite || pokemonManager.AutoUpgrade))
                        .OrderByDescending(poke => manager.CalculateIVPerfection(poke).Data)
                        .ThenBy(poke => poke.Cp)
                        .Take(pokemonManager.Quantity));
            }

            return pokemonToHandle;
        }

        public async void EvolvePokemon(IManager manager, List<PokemonData> pokesToEvolve)
        {
            if (pokesToEvolve.Count == 0) return;

            var results = await manager.EvolvePokemon(pokesToEvolve);

            OnLogEvent(this,
                GetLog(new MethodResult()
                {
                    Success = results.Success,
                    Message = results.Message,
                    MethodName = "EvolvePokemon",
                }));
        }

        public async void UpgradePokemon(IManager manager, List<PokemonData> pokesToUpgrade)
        {
            if (pokesToUpgrade.Count == 0) return;
            var results = await manager.UpgradePokemon(pokesToUpgrade, 100);

            OnLogEvent(this,
                GetLog(new MethodResult()
                {
                    Success = results.Success,
                    Message = results.Message,
                    MethodName = "UpgradePokemon",
                }));
        }

        public async void SetFavorites(IManager manager, List<PokemonData> pokesToFavorite)
        {
            if (pokesToFavorite.Count == 0) return;

            var results = await manager.FavoritePokemon(pokesToFavorite, true);

            OnLogEvent(this,
                GetLog(new MethodResult()
                {
                    Success = results.Success,
                    Message = results.Message,
                    MethodName = "FavoritePokemon",
                }));
        }

        public override async Task<MethodResult> Enable(bool forceSubscribe = false)
        {
            await LoadSettings();

            if (Settings.Enabled)
            {
                _taskTimer.Interval = Settings.Extra.IntervalMilliseconds;

                _taskTimer.Elapsed += _taskTimer_Elapsed;
                _taskTimer.Enabled = true;
                OnModuleEvent(this, Modules.ModuleEvent.Enabled);
                Execute();
            }

            return new MethodResult {Success = Settings.Enabled};
        }

        public override async Task<MethodResult> Disable(bool forceUnsubscribe = false)
        {
            if (!_taskTimer.Enabled) return new MethodResult {Success = true};
            _taskTimer.Elapsed -= _taskTimer_Elapsed;
            _taskTimer.Enabled = false;
            await SaveSettings();
            OnModuleEvent(this, Modules.ModuleEvent.Disabled);
            return new MethodResult {Success = true};
        }

        public async Task<MethodResult> LoadSettings()
        {
            var loadSettingsResult = await Settings.Load(ModuleName);

            if (!loadSettingsResult.Success)
            {
                Settings.Extra = new PokemonManagerSettings(true);
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
    }
}