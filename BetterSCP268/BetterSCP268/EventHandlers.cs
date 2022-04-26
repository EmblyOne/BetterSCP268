
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
        public Better268 plugin;
        public EventHandlers(Better268 plugin) => this.plugin = plugin;
        public void OnHurt268(HurtingEventArgs ev)
        {
            if (ev.Target.GetEffectActive<Invisible>() && plugin.Config.Damage)
                ev.IsAllowed = false; 
        } 
        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (ev.Player.GetEffectActive<Invisible>() && plugin.Config.Tesla)
                ev.IsTriggerable = false;
        }
        public void OnUsingSCP(UsingItemEventArgs ev)
        {
            if (ev.Item.Type == ItemType.SCP268)
                Timing.RunCoroutine(DetectCoroutine(ev.Player), "BetterSCP268Coroutine");  
        }
        public void OnAddingTarget(AddingTargetEventArgs ev)
        {
            if (ev.Target.GetEffectActive<Invisible>() && plugin.Config.SCP096)
                ev.IsAllowed = false;
        }
      
        public void OnDamage(HurtingEventArgs ev)
        {
            if (ev.Target.GetEffectActive<Invisible>())  
            {
                switch (ev.Handler.Type)
                {
                    case DamageType.Falldown:
                        ev.IsAllowed = plugin.Config.Falldown;
                        return;
                    case DamageType.Hypothermia:
                        ev.IsAllowed = plugin.Config.SCP244;
                        return;

                }
            }
        }
        public IEnumerator<float> DetectCoroutine(Player Scp330Player)
        {
            for (; ; )
            {

                yield return Timing.WaitForSeconds(1);
                foreach (Player player in Player.List)
                {
                    if (player == Scp330Player) continue;
                    if (Vector3.Distance(player.Position, Scp330Player.Position) <= plugin.Config.Distance)
                    {
                        player.Broadcast((ushort)plugin.Config.BroadcastTime, plugin.Config.Broadcast);
                        yield break; 
                    }

                }
            }
        } 
        public void OnRoundEnd(EndingRoundEventArgs ev)
        {
            Timing.KillCoroutines("BetterSCP268Coroutine");
        }
    }
}
