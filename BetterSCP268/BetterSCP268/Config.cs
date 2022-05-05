using System.ComponentModel;
using Exiled.API.Interfaces;

namespace BetterSCP268
{
    public class Config : IConfig
    {
        [Description("Whether or not this plugin is enabled")]
        public bool IsEnabled { get; set; } = false;

        [Description("No damage will be dealt to the player with SCP-268")]
        public bool CanDamage { get; set; } = true;

        [Description("it will show broadcast to the player if there is a player next to SCP-268")]
        public string SendBroadcast { get; set; } = "<b>A player with <color=#4fd411>SCP-268</color> next to you </b>";

        [Description("Tesla will be disabled if SCP-268 goes through the tesla")]
        public bool DisableTesla { get; set; } = true;

        [Description("SCP-096 can't see if player uses SCP-268")]
        public bool Scp096Trigger { get; set; } = true;

        [Description("The distance between players from which the broadcast will show")]
        public int Scp330Distance { get; set; } = 16;

        [Description("Time the loop waits before loopig again, increase for more performance, but less accurate position broadcasts")]
        public ushort BroadcastDelay { get; set; } = 1;

        [Description("You won't get damage when you will fall with SCP-268(false = you won't get damage, true = you will get)")]
        public bool CanFallDown { get; set; } = false;

        [Description("You won't get damage when you will be near SCP-244 (false = you won't get damage, true = you will get)")]
        public bool DisableScp244Damage { get; set; } = false;
    }
}