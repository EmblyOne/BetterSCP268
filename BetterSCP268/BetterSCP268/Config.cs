using Exiled.API.Features;
using System.ComponentModel;
using Exiled.API.Interfaces;
namespace BetterSCP268
{
    public class Config : IConfig
    {
        [Description("Whether or not this plugin is enabled")]
        public bool IsEnabled { get; set; } = true;

        [Description("No damage will be dealt to the player with SCP-268")]  
        public bool damage { get; set; } = true;

        [Description("it will show broadcast to the player if there is a player next to SCP-268")]
        public string bc { get; set; } = "<b>A player with <color=#4fd411>SCP-268</color> next to you </b>";

        [Description("How long will show broadcast")]
        public int bctime { get; set; } = 10;

        [Description("Tesla will be disabled if SCP-268 goes through the tesla")]  
        public bool tesla { get; set; } = true;

        [Description("SCP-096 can't see if player uses SCP-268")]
        public bool scp096 { get; set; } = true;

        [Description("The distance between players from which the broadcast will show")]
        public int dis { get; set; } = 16; 

        [Description("It will turn on door patch for SCP-268(you can open doors if you are SCP-268 and stay invisible)")]
        public bool doorpatch { get; set; } = true; 

        [Description("You won't get damage when you will fall with SCP-268(false = you won't get damage, true = you will get)")]
        public bool falldown { get; set; } = false;

        [Description("You won't get damage when you will be near SCP-244 (false = you won't get damage, true = you will get)")]
        public bool scp244 { get; set; } = false;
    }
}
