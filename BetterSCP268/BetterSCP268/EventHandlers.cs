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
            if (ev.Target.GetEffectActive<CustomPlayerEffects.Invisible>()  && plugin.Config.damage)
            {
                ev.IsAllowed = false;
            }
        } 
        public void OnFlashed(HurtingEventArgs ev)
        {
            if(ev.Target.GetEffectActive<CustomPlayerEffects.Flashed>() && ev.Target.GetEffectActive<CustomPlayerEffects.Invisible>() && plugin.Config.flashed)
            {
                ev.IsAllowed = false; 
            }
        }
        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (ev.Player.GetEffectActive<CustomPlayerEffects.Invisible>() && plugin.Config.tesla)
            {
                ev.IsTriggerable = false;
                Log.Debug("Player with SCP-268 didn't trigger by tesla");

            }

        } 
     

        public void OnUsingSCP(UsingItemEventArgs ev)
        {
            if (ev.Item.Type == ItemType.SCP268)
            {

                Timing.RunCoroutine(DetectCoroutine(ev.Player));
                Log.Debug("DetectCoroutine has activated");

            }

        }
        public void OnAddingTarget(AddingTargetEventArgs ev)
        {
            if (ev.Target.GetEffectActive<CustomPlayerEffects.Invisible>() && plugin.Config.scp096)
            {
                ev.IsAllowed = false;
                Log.Debug("Player with SCP-268 didn't add to the SCP-096 Target");
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
