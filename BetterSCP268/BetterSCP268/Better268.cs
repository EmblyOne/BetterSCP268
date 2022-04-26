using System;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using HarmonyLib;
using Player = Exiled.Events.Handlers.Player;
using Scp096 = Exiled.Events.Handlers.Scp096; 

namespace BetterSCP268
{
    public class Better268 : Plugin<Config>
    { 
        public override string Author { get; } = "G-Man";
        public override string Name { get; } = "BetterSCP268";
        public override string Prefix { get; } = "BetterSCP268";
        public override Version Version { get; } = new Version(2,0,0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 1, 3);
        public EventHandlers EventHandler;
        public Better268 plugin; 
        public Harmony harmony = new Harmony("InteractSCP268Patch"); 
        public override void OnEnabled()
        {
            plugin = new Better268();
            EventHandler = new EventHandlers(this); 
            if(plugin.Config.doorpatch)
            {
                harmony.PatchAll();
            }
            Player.Hurting += EventHandler.OnHurt268; 
            Player.TriggeringTesla += EventHandler.OnTriggeringTesla;
            Player.UsingItem += EventHandler.OnUsingSCP;
            Scp096.AddingTarget += EventHandler.OnAddingTarget;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            harmony.UnpatchAll("InteractSCP268Patch");
            Player.Hurting -= EventHandler.OnHurt268;
            Player.TriggeringTesla -= EventHandler.OnTriggeringTesla;
            Scp096.AddingTarget -= EventHandler.OnAddingTarget;
            Player.UsingItem -= EventHandler.OnUsingSCP;
            EventHandler = null; 
        }
    }
}
