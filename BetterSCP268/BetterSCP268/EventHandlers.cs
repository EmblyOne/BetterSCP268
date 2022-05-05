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
        private readonly Dictionary<Player, CoroutineHandle> _playerHandleList = new Dictionary<Player, CoroutineHandle>();
        
        private readonly Config _config = Plugin.Instance.Config;
        
        public void OnHurting(HurtingEventArgs ev)
        {
            if (_config.CanDamage && ev.Target.GetEffectActive<Invisible>())
                ev.IsAllowed = false;
        }

        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (_config.DisableTesla && ev.Player.GetEffectActive<Invisible>())
                ev.IsTriggerable = false;
        }

        public void OnUsingSCP(UsingItemEventArgs ev)
        {
            if (!_playerHandleList.ContainsKey(ev.Player) && ev.Item.Type == ItemType.SCP268) 
                _playerHandleList.Add(ev.Player, Timing.RunCoroutine(DetectCoroutine(ev.Player)));
        }

        public void OnAddingTarget(AddingTargetEventArgs ev)
        {
            if (_config.Scp096Trigger && ev.Target.GetEffectActive<Invisible>())
                ev.IsAllowed = false;
        }

        public void OnRoundEnd(EndingRoundEventArgs ev)
        {
            foreach (var item in _playerHandleList)
            {
                Timing.KillCoroutines(item.Value);
            }

            _playerHandleList.Clear();
        }
        
        private IEnumerator<float> DetectCoroutine(Player scp330Player)
        {
            for (;;)
            {
                foreach (Player player in Player.List)
                {
                    if (player == scp330Player) continue;
                    
                    if (Vector3.Distance(player.Position, scp330Player.Position) <= _config.Scp330Distance)
                        player.Broadcast(_config.BroadcastDelay, _config.SendBroadcast);
                }

                if (!scp330Player.GetEffectActive<Invisible>())
                {
                    Timing.KillCoroutines(_playerHandleList[scp330Player]);
                    _playerHandleList.Remove(scp330Player);
                }

                yield return Timing.WaitForSeconds(_config.BroadcastDelay);
            }
        }
    }
}