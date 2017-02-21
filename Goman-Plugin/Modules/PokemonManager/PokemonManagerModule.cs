using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Goman_Plugin.Model;
using GoPlugin;
using GoPlugin.Enums;
using POGOProtos.Data;
using POGOProtos.Data.Player;
using MethodResult = Goman_Plugin.Model.MethodResult;
using Timer = System.Timers.Timer;

namespace Goman_Plugin.Modules.PokemonManager
{
    public class PokemonManagerModule : AbstractModule
    {
        public new BaseSettings<PokemonManagerSettings> Settings { get; }
        private static Timer _taskTimer;
        public PokemonManagerModule()
        {
            Settings = new BaseSettings<PokemonManagerSettings>() { Enabled = true};
            _taskTimer = new Timer();
            _taskTimer.Elapsed += _taskTimer_Elapsed;
        }

        private void _taskTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
           Execute();
        }

        private void Execute()
        {

            foreach (var account in Plugin.Accounts)
            {
                if(account.Bot.State != BotState.Running) continue;
                account.Bot.UpdateDetails().ContinueWith(s =>
                {
                    if (!s.Result.Success) return;

                    var pokesToFavorite = new List<PokemonData>();
                    var pokesToUpgrade = new List<PokemonData>();
                    var pokesToEvolve = new List<PokemonData>();
                    var pokemonToHandle = GetPokemonToHandle(account.Bot);


                    foreach (var pokemonData in pokemonToHandle)
                    {
                        var pokeSetting = Settings.Extra.Pokemons[pokemonData.PokemonId];
                        var pokemonSettings = account.Bot.GetPokemonSetting(pokemonData.PokemonId).Data;

                        var totalCandy =
                            account.Bot.PokemonCandy.Where(x => x.FamilyId == pokemonSettings.FamilyId)
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

                            if (pokeSetting.AutoUpgrade && totalCandy > 0)
                                pokesToUpgrade.Add(pokemonData);
                        }
                    }

                    EvolvePokemon(account.Bot, pokesToEvolve);
                    UpgradePokemon(account.Bot, pokesToUpgrade);
                    SetFavorites(account.Bot, pokesToFavorite);
                });
            }
            
        }

        public List<PokemonData> GetPokemonToHandle(IManager manager)
        {
            var pokemonToHandle = new List<PokemonData>();

            foreach (var pokemonManager in Settings.Extra.Pokemons.Values)
            {
                pokemonToHandle
                .AddRange(manager.Pokemon
                .Where(poke => manager.CalculateIVPerfection(poke).Data >= pokemonManager.MinimumIv && poke.Cp >= pokemonManager.MinimumCp && (pokemonManager.AutoEvolve || pokemonManager.AutoFavorite || pokemonManager.AutoUpgrade))
                .OrderByDescending(poke => manager.CalculateIVPerfection(poke).Data)
                .ThenBy(poke => poke.Cp)
                .Take(pokemonManager.Quantity));
            }

            return pokemonToHandle;
        }
        public void EvolvePokemon(IManager manager, List<PokemonData> pokesToEvolve)
        {
            if (pokesToEvolve.Count > 0)
            {
                manager.EvolvePokemon(pokesToEvolve).ContinueWith(r =>
                {
                    var results = r.Result;

                    OnLogEvent(this,
                        GetLog(new MethodResult()
                        {
                            Success = results.Success,
                            Message = results.Message,
                            MethodName = "EvolvePokemon",
                            Error = r.Exception?.Flatten().InnerException
                        }));
                });
            }
        }
        public void UpgradePokemon(IManager manager, List<PokemonData> pokesToUpgrade)
        {
            if (pokesToUpgrade.Count > 0)
            {
                manager.UpgradePokemon(pokesToUpgrade, 100).ContinueWith(r =>
                {
                    var results = r.Result;

                    OnLogEvent(this,
                        GetLog(new MethodResult()
                        {
                            Success = results.Success,
                            Message = results.Message,
                            MethodName = "UpgradePokemon",
                            Error = r.Exception?.Flatten().InnerException
                        }));
                });
            }
        }
        public void SetFavorites(IManager manager, List<PokemonData> pokesToFavorite)
        {
            if (pokesToFavorite.Count > 0)
            {
                manager.FavoritePokemon(pokesToFavorite, true).ContinueWith(r =>
                {
                    var results = r.Result;

                    OnLogEvent(this,
                        GetLog(new MethodResult()
                        {
                            Success = results.Success,
                            Message = results.Message,
                            MethodName = "FavoritePokemon",
                            Error = r.Exception?.Flatten().InnerException
                        }));
                });
            }
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

            return new MethodResult { Success = Settings.Enabled };
        }

        public override async Task<MethodResult> Disable(bool forceUnsubscribe = false)
        {
            if (!_taskTimer.Enabled) return new MethodResult { Success = true };
            _taskTimer.Elapsed -= _taskTimer_Elapsed;
            _taskTimer.Enabled = false;
            await SaveSettings();
            OnModuleEvent(this, Modules.ModuleEvent.Disabled);
            return new MethodResult { Success = true };
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
