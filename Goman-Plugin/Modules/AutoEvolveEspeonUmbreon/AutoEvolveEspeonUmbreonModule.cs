using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goman_Plugin.Wrapper;
using GoPlugin;
using GoPlugin.Enums;
using POGOProtos.Data;
using MethodResult = Goman_Plugin.Model.MethodResult;
using Timer = System.Timers.Timer;

namespace Goman_Plugin.Modules.AutoEvolveEspeonUmbreon
{
    public class AutoEvolveEspeonUmbreonModule : AbstractModule
    {
        public new BaseSettings<AutoEvolveEspeonUmbreonSettings> Settings { get; }

        public AutoEvolveEspeonUmbreonModule()
        {
            Settings = new BaseSettings<AutoEvolveEspeonUmbreonSettings>() { Enabled = true };
            Plugin.ManagerAdded -= PluginOnManagerAdded;
            Plugin.ManagerRemoved -= PluginOnManagerRemoved;
        }

        public override async Task<MethodResult> Enable(bool forceSubscribe = false)
        {
            await LoadSettings();

            if (Settings.Enabled)
            {               
                OnModuleEvent(this, Modules.ModuleEvent.Enabled);
            }

            return new MethodResult { Success = Settings.Enabled };
        }


        public override async Task<MethodResult> Disable(bool forceUnsubscribe = false)
        {
            await SaveSettings();
            OnModuleEvent(this, Modules.ModuleEvent.Disabled);
            return new MethodResult { Success = true };
        }

        public async Task<MethodResult> LoadSettings()
        {
            var loadSettingsResult = await Settings.Load(ModuleName);

            if (!loadSettingsResult.Success)
            {
                Settings.Extra = new AutoEvolveEspeonUmbreonSettings();
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
            manager.Bot.OnAccountStart += OnAccountStart;
            manager.Bot.OnAccountStop += OnAccountStop;
            OnLogEvent(this, new Model.LogModel(LoggerTypes.Debug, "MANAGER ADDED", "", null), manager.Bot);
        }

        private void PluginOnManagerRemoved(object o, Manager manager)
        {
            // OnLogEvent(this, new LogModel(LoggerTypes.Info, $"Unsubscribing to account {manager.Bot.AccountName}"));
            manager.Bot.OnAccountStart -= OnAccountStart;
            manager.Bot.OnAccountStop -= OnAccountStop;

        }

        private async void OnAccountStart(object sender, EventArgs e)
        {
            OnLogEvent(this, new Model.LogModel(LoggerTypes.Debug, "START", "", null));
            await Task.Delay(30000);
            var wrapperManager=Plugin.Accounts.Single(x => x.Bot == (IManager)sender);

            if (!wrapperManager.Bot.IsRunning) return;

            Execute(wrapperManager);
            wrapperManager.RunningTimeTimer = new Timer(Settings.Extra.IntervalMilliseconds) {AutoReset = true};
            wrapperManager.RunningTimeTimer.Elapsed += (s, a) => OnTimerElapsed(sender, e, wrapperManager);
            wrapperManager.RunningTimeTimer.Start();
        }

        private void OnAccountStop(object sender, EventArgs e)
        {
            var wrapperManager = Plugin.Accounts.Single(x => x.Bot == (IManager)sender);
            wrapperManager.RunningTimeTimer.Close();
            wrapperManager.RunningTimeTimer.Dispose();

        }
        private void OnTimerElapsed(object sender, EventArgs e, Manager manager)
        {
            OnLogEvent(this, new Model.LogModel(LoggerTypes.Debug, "ELAPSED", "", null),manager.Bot);
            if (manager.Bot.State != BotState.Running) return;

            IEnumerable<PokemonData> eevees = manager.Bot.Pokemon.Where(poke => (int)poke.PokemonId == 133).OrderByDescending(poke => poke.Cp);

            DoEeveeStuff(eevees, manager);
        }
        private void Execute(Manager manager)
        {
            OnLogEvent(this, new Model.LogModel(LoggerTypes.Debug, "EXECUTE", "", null), manager.Bot);
            if (manager.Bot.State != BotState.Running) return;
            var eevees = manager.Bot.Pokemon.Where(poke => (int)poke.PokemonId == 133).OrderByDescending(poke => poke.Cp);


            DoEeveeStuff(eevees, manager);
        }

        private static async void DoEeveeStuff(IEnumerable<PokemonData> eevees, Manager manager)
        {
            var pokemonDatas = eevees as PokemonData[] ?? eevees.ToArray();

            if (!pokemonDatas.Any()) return;
            if (pokemonDatas.Any(x => x.BuddyTotalKmWalked > 0))
            {
                var ienumerableEevee = pokemonDatas.Where(x => x.BuddyTotalKmWalked >= 10).Take(1);
                await manager.Bot.EvolvePokemon(ienumerableEevee);

            }
            else
            {
                await manager.Bot.SetBuddyPokemon(pokemonDatas.ElementAt(0));
            }
        }

    }
}