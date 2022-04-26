
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
            if (ev.Target.GetEffectActive<CustomPlayerEffects.Invisible>() && plugin.Config.damage)
                ev.IsAllowed = false; 
        } 
        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (ev.Player.GetEffectActive<CustomPlayerEffects.Invisible>() && plugin.Config.tesla)
                ev.IsTriggerable = false;
        }
        public void OnUsingSCP(UsingItemEventArgs ev)
        {
            if (ev.Item.Type == ItemType.SCP330)
                Timing.RunCoroutine(DetectCoroutine(ev.Player), "BetterSCP268Coroutine");  
        }
        public void OnAddingTarget(AddingTargetEventArgs ev)
        {
            if (ev.Target.GetEffectActive<CustomPlayerEffects.Invisible>() && plugin.Config.scp096)
                ev.IsAllowed = false;
        }
      
        public void OnDamage(HurtingEventArgs ev)
        {
            if (ev.Target.GetEffectActive<CustomPlayerEffects.Invisible>())  
            {
                switch (ev.Handler.Type)
                {
                    case DamageType.Falldown:
                        ev.IsAllowed = plugin.Config.falldown;
                        return;
                    case DamageType.Hypothermia:
                        ev.IsAllowed = plugin.Config.scp244;
                        return;

                }
            }
        }
        public IEnumerator<float> DetectCoroutine(Player player1)
        {
            for (; ; )
            {

                yield return Timing.WaitForSeconds(1);
                foreach (Player player in Player.List)
                {
                    if (player == player1) continue;
                    if (Vector3.Distance(player.Position, player1.Position) <= plugin.Config.dis)
                    {
                        player.Broadcast((ushort)plugin.Config.bctime, plugin.Config.bc);
                        yield break; 
                    }

                }
            }
        } 
        public void OnRoundRestart()
        {
            Timing.KillCoroutines("BetterSCP268Coroutine");
        }
    }
}
