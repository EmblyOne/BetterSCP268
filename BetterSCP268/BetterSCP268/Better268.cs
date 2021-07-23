using System;
using Exiled.API.Features;
using Exiled.API.Interfaces; 
using Player = Exiled.Events.Handlers.Player;
using Scp096 = Exiled.Events.Handlers.Scp096; 

namespace BetterSCP268
{
    public class Better268 : Plugin<Config>
    { 
        public override string Author { get; } = "G-Man";
        public override string Name { get; } = "BetterSCP268";
        public override string Prefix { get; } = "BetterSCP268";
        public override Version Version { get; } = new Version(1,0,0);
   
        public override Version RequiredExiledVersion { get; } = new Version(2, 10, 0);

        public EventHandlers EventHandler;

        public override void OnEnabled()
        { 
            if(!Config.IsEnabled) return;
            EventHandler = new EventHandlers(this);
            Player.Hurting += EventHandler.OnHurt268;
            Player.TriggeringTesla += EventHandler.OnTriggeringTesla;
            Player.UsingMedicalItem += EventHandler.OnUsingSCP;
            Scp096.AddingTarget += EventHandler.OnAddingTarget;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.Hurting -= EventHandler.OnHurt268;
            Player.TriggeringTesla -= EventHandler.OnTriggeringTesla;
            Scp096.AddingTarget -= EventHandler.OnAddingTarget;
            Player.UsingMedicalItem -= EventHandler.OnUsingSCP;
            EventHandler = null; 
        }
    }
}
