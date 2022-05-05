
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using CustomPlayerEffects;
using Exiled.API.Features.Items;
using System.Collections.Generic;
using MEC;
using UnityEngine;
using Exiled.API.Enums;

namespace BetterSCP268
{
    public class EventHandlers
    {
        public Dictionary<Player, CoroutineHandle> playerhandlelist = new Dictionary<Player, CoroutineHandle>();
        public Better268 plugin;
        public EventHandlers(Better268 plugin) => this.plugin = plugin;
        
        public void OnHurt268(HurtingEventArgs ev)
        {
            if (plugin.Config.CanDamage && ev.Target.GetEffectActive<Invisible>())
                ev.IsAllowed = false; 
        }  

        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (plugin.Config.DiableTesla && ev.Player.GetEffectActive<Invisible>())
                ev.IsTriggerable = false;
        } 

        public void OnUsingSCP(UsingItemEventArgs ev)
        {
            if (!playerhandlelist.ContainsKey(ev.Player) && ev.Item.Type == ItemType.SCP268)  
               playerhandlelist.Add(ev.Player, Timing.RunCoroutine(DetectCoroutine(ev.Player)));
            
        } 

        public void OnAddingTarget(AddingTargetEventArgs ev)
        {
            if (plugin.Config.SCP096Trigger && ev.Target.GetEffectActive<Invisible>())
                ev.IsAllowed = false;
        }
        public void OnDamage(HurtingEventArgs ev)
        {
            if (ev.Target.GetEffectActive<Invisible>())  
            {
                switch (ev.Handler.Type)
                {
                    case DamageType.Falldown:
                        ev.IsAllowed = plugin.Config.CanFalldown;
                        return;
                    case DamageType.Hypothermia:
                        ev.IsAllowed = plugin.Config.DisableSCP244Damage;
                        return;

                }
            }
        }
        public IEnumerator<float> DetectCoroutine(Player Scp330Player)
        {
            for (; ;)
            {
                foreach (Player player in Player.List)
                {
                    if (player == Scp330Player) continue;
                    if (Vector3.Distance(player.Position, Scp330Player.Position) <= plugin.Config.Scp330Distance) 
                        player.Broadcast(plugin.Config.broadcastDelay, plugin.Config.SendBroadcast);
                }
                if (!Scp330Player.GetEffectActive<Invisible>())
                {
                    Timing.KillCoroutines(playerhandlelist[Scp330Player]);
                    playerhandlelist.Remove(Scp330Player);
                }
                yield return Timing.WaitForSeconds(plugin.Config.broadcastDelay);
            }
        } 
        public void OnRoundEnd(EndingRoundEventArgs ev)
        {
            foreach (var item in playerhandlelist)
            {
                Timing.KillCoroutines(item.Value);
            } 
            playerhandlelist.Clear();
        } 
    }
}
