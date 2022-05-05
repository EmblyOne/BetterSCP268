using System;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Scp096 = Exiled.Events.Handlers.Scp096;
using Round = Exiled.Events.Handlers.Server; 
namespace BetterSCP268
{
    public class Better268 : Plugin<Config>
    { 
        public override string Author { get; } = "G-Man";
        public override string Name { get; } = "BetterSCP268";
        public override string Prefix { get; } = "BetterSCP268";
        public override Version Version { get; } = new Version(3,0,0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 2, 0);
        public EventHandlers EventHandler; 
        public override void OnEnabled()
        {
            EventHandler = new EventHandlers(this); 
            Player.Hurting += EventHandler.OnHurt268;
            Round.EndingRound += EventHandler.OnRoundEnd;
            Player.TriggeringTesla += EventHandler.OnTriggeringTesla;
            Player.UsingItem += EventHandler.OnUsingSCP;
            Scp096.AddingTarget += EventHandler.OnAddingTarget;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.Hurting -= EventHandler.OnHurt268;
            Round.EndingRound -= EventHandler.OnRoundEnd;
            Player.TriggeringTesla -= EventHandler.OnTriggeringTesla;
            Scp096.AddingTarget -= EventHandler.OnAddingTarget;
            Player.UsingItem -= EventHandler.OnUsingSCP;
            EventHandler = null;
            base.OnDisabled();
        }
    }
}
