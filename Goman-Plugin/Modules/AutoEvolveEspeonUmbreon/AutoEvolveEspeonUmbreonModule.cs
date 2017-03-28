using System;
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
using Goman_Plugin.Modules.AutoEvolveEspeonUmbreon;
using GoPlugin.Events;

namespace Goman_Plugin.Modules.AutoEvolveEspeonUmbreon
{
    public class AutoEvolveEspeonUmbreonModule : AbstractModule
    {
        public new BaseSettings<AutoEvolveEspeonUmbreonSettings> Settings { get; }
        private Plugin _plugin;

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

        private async void PluginOnManagerAdded(object o, Manager manager)
        {
            // OnLogEvent(this, new LogModel(LoggerTypes.Info, $"Subscribing to account {manager.Bot.AccountName}"));
            manager.Bot.OnAccountStart += OnAccountStart;
            manager.Bot.OnAccountStop += OnAccountStop;
            await Plugin.AutoEvolveEspeonUmbreonModule.AddLog(new Model.LogModel(LoggerTypes.Debug, "MANAGER ADDED", "", null), null);
        }

        private void PluginOnManagerRemoved(object o, Manager manager)
        {
            // OnLogEvent(this, new LogModel(LoggerTypes.Info, $"Unsubscribing to account {manager.Bot.AccountName}"));
            manager.Bot.OnAccountStart -= OnAccountStart;
            manager.Bot.OnAccountStop -= OnAccountStop;

        }

        private async void OnAccountStart(object sender, EventArgs e)
        {
            await Plugin.AutoEvolveEspeonUmbreonModule.AddLog(new Model.LogModel(LoggerTypes.Debug, "START", "", null), null);
            await Task.Delay(30000);
            var wrapperManager=Plugin.Accounts.Single(x => x.Bot == (IManager)sender);
            if (wrapperManager.Bot.IsRunning)
            {
                Execute(wrapperManager);
                wrapperManager.RunningTimeTimer= new Timer(Settings.Extra.IntervalMilliseconds);
                wrapperManager.RunningTimeTimer.AutoReset = true;
                wrapperManager.RunningTimeTimer.Elapsed += (s, a) => OnTimerElapsed(sender, e, wrapperManager);
                wrapperManager.RunningTimeTimer.Start();               
            }
        }

        private void OnAccountStop(object sender, EventArgs e)
        {
            var wrapperManager = Plugin.Accounts.Single(x => x.Bot == (IManager)sender);
            wrapperManager.RunningTimeTimer.Close();
            wrapperManager.RunningTimeTimer.Dispose();

        }
        private async void OnTimerElapsed(object sender, EventArgs e, Manager manager)
        {
            await Plugin.AutoEvolveEspeonUmbreonModule.AddLog(new Model.LogModel(LoggerTypes.Debug, "ELAPSED", "", null), null);
            if (manager.Bot.State == BotState.Running)
            {
                IEnumerable<PokemonData> eevees = manager.Bot.Pokemon.Where(poke => (int)poke.PokemonId == 133).OrderByDescending(poke => poke.Cp);
                if (eevees.Count() > 0)
                {
                    if (eevees.Any(x => x.BuddyTotalKmWalked > 0))
                    {
                        IEnumerable<PokemonData> ienumerable_eevee = eevees.Where(x => x.BuddyTotalKmWalked >= 10).Take(1);
                        if (ienumerable_eevee.Count() > 0)
                        {
                            await manager.Bot.EvolvePokemon(ienumerable_eevee);
                        }
                    }
                    else
                    {
                        await manager.Bot.SetBuddyPokemon(eevees.ElementAt(0));
                    }
                }
            }
        }
        private async void Execute(Manager manager)
        {
            await Plugin.AutoEvolveEspeonUmbreonModule.AddLog(new Model.LogModel(LoggerTypes.Debug, "EXECUTE", "", null), null);
            if (manager.Bot.State == BotState.Running)
            {
                IEnumerable<PokemonData> eevees = manager.Bot.Pokemon.Where(poke => (int)poke.PokemonId == 133).OrderByDescending(poke => poke.Cp);
                if (eevees.Count() > 0)
                {
                    if (eevees.Any(x => x.BuddyTotalKmWalked > 0))
                    {
                        IEnumerable<PokemonData> ienumerable_eevee = eevees.Where(x => x.BuddyTotalKmWalked >= 10).Take(1);
                        if (ienumerable_eevee.Count() > 0)
                        {
                            await manager.Bot.EvolvePokemon(ienumerable_eevee);
                        }
                    }
                    else
                    {
                        await manager.Bot.SetBuddyPokemon(eevees.ElementAt(0));
                    }
                }
            }
        }

    }
}