using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Goman_Plugin.Wrapper;
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
        }

        private void _taskTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Execute();
        }

        public void Execute()
        {
            foreach (var manager in Plugin.Accounts)
            {
                if (manager.Bot.State != BotState.Running) continue;


                var pokesToFavorite = new List<PokemonData>();
                var pokesToUpgrade = new List<PokemonData>();
                var pokesToEvolve = new List<PokemonData>();
                var pokemonToHandle = GetPokemonToHandle(manager.Bot);


                foreach (var pokemonData in pokemonToHandle)
                {
                    var pokeSetting = Settings.Extra.Pokemons[pokemonData.PokemonId];
                    var pokemonSettings = manager.Bot.GetPokemonSetting(pokemonData.PokemonId).Data;

                    var totalCandy =
                        manager.Bot.PokemonCandy
                            .FirstOrDefault(x => x.FamilyId == pokemonSettings.FamilyId)?.Candy_;

                    var candyToEvolve = pokemonSettings.CandyToEvolve;


                    if (pokeSetting.AutoEvolve && candyToEvolve > 0 && totalCandy >= candyToEvolve)
                    {
                        pokesToEvolve.Add(pokemonData);
                    }
                    else
                    {
                        if (pokeSetting.AutoFavorite && pokemonData.Favorite == 0) pokesToFavorite.Add(pokemonData);
                        if (pokeSetting.AutoUpgrade && totalCandy > 3) pokesToUpgrade.Add(pokemonData);
                    }
                }

                EvolvePokemon(manager, pokesToEvolve);
                UpgradePokemon(manager, pokesToUpgrade);
                SetFavorites(manager, pokesToFavorite);
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

        public async void EvolvePokemon(Manager manager, List<PokemonData> pokesToEvolve)
        {
            if (pokesToEvolve.Count == 0 || manager.AutoEvolving) return;
            manager.AutoEvolving = true;
           // MessageBox.Show("Start AutoEvolving");
            await manager.Bot.EvolvePokemon(pokesToEvolve).ContinueWith(r =>
            {
                var results = r.Result;

                OnLogEvent(this,
                    GetLog(new MethodResult()
                    {
                        Success = results.Success,
                        Message = results.Message,
                        MethodName = "EvolvePokemon",
                    }));
               // MessageBox.Show("End AutoEvolving");
                manager.AutoEvolving = false;
            });


        }

        public void UpgradePokemon(Manager manager, List<PokemonData> pokesToUpgrade)
        {
            if (pokesToUpgrade.Count == 0 || manager.AutoUpgrading) return;
            manager.AutoUpgrading = true;
            //MessageBox.Show("Start AutoUpgrading");
            manager.Bot.UpgradePokemon(pokesToUpgrade, 100).ContinueWith(r =>
            {
                var results = r.Result;

                            OnLogEvent(this,
                GetLog(new MethodResult()
                {
                    Success = results.Success,
                    Message = results.Message,
                    MethodName = "UpgradePokemon",
                }));
                //MessageBox.Show("End AutoUpgrading");
                manager.AutoUpgrading = false;
            });
        }

        public void SetFavorites(Manager manager, List<PokemonData> pokesToFavorite)
        {
            if (pokesToFavorite.Count == 0 || manager.AutoFavoriting) return;
            manager.AutoFavoriting = true;
           // MessageBox.Show("Start SetFavorites");
            manager.Bot.FavoritePokemon(pokesToFavorite).ContinueWith(r =>
            {
                var results = r.Result;

                OnLogEvent(this,
                    GetLog(new MethodResult()
                    {
                        Success = results.Success,
                        Message = results.Message,
                        MethodName = "FavoritePokemon",
                    }));
               // MessageBox.Show("End SetFavorites");
                manager.AutoFavoriting = false;
            });
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