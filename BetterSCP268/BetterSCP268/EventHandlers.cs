using System;
using System.Collections;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using CustomPlayerEffects; 
using System.Collections.Generic;
using MEC;
using UnityEngine;

namespace BetterSCP268
{
    public class EventHandlers
    {
        public Better268 plugin;
        public EventHandlers(Better268 plugin) => this.plugin = plugin;
        

         
       
        public void OnHurt268(HurtingEventArgs ev)
        {
            if (ev.Target.GetEffectActive<CustomPlayerEffects.Scp268>() && plugin.Config.damage)
            {
                ev.IsAllowed = false; 
            }
        } 
        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (ev.Player.GetEffectActive<CustomPlayerEffects.Scp268>() && plugin.Config.tesla)
            {
                ev.IsTriggerable = false;

            }

        }

        public void OnUsingSCP(UsedMedicalItemEventArgs ev)
        {
            if (ev.Item == ItemType.SCP268)
            {
           
                Timing.RunCoroutine(DetectCoroutine(ev.Player)); 

            } 
            
        }
        public void OnAddingTarget(AddingTargetEventArgs ev)
        {
            if (ev.Target.GetEffectActive<CustomPlayerEffects.Scp268>() && plugin.Config.scp096)
            {
                ev.IsAllowed = false;
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
                        player.Broadcast((ushort)plugin.Config.bctime, plugin.Config.bc, 0);
                        yield break; 
                    }

                }
            }

            
        }
         
   
       
    }
}
