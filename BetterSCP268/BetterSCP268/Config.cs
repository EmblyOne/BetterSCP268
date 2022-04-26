
using System.ComponentModel;
using Exiled.API.Interfaces;
namespace BetterSCP268
{
    public class Config : IConfig
    {
        [Description("Whether or not this plugin is enabled")]
        public bool IsEnabled { get; set; } = true;

        [Description("No damage will be dealt to the player with SCP-268")]  
        public bool Damage { get; set; } = true;

        [Description("it will show broadcast to the player if there is a player next to SCP-268")]
        public string Broadcast { get; set; } = "<b>A player with <color=#4fd411>SCP-268</color> next to you </b>";

        [Description("How long will show broadcast")]
        public int BroadcastTime { get; set; } = 10;

        [Description("Tesla will be disabled if SCP-268 goes through the tesla")]  
        public bool Tesla { get; set; } = true;

        [Description("SCP-096 can't see if player uses SCP-268")]
        public bool SCP096 { get; set; } = true;

        [Description("The distance between players from which the broadcast will show")]
        public int Distance { get; set; } = 16; 

        [Description("You won't get damage when you will fall with SCP-268(false = you won't get damage, true = you will get)")]
        public bool Falldown { get; set; } = false;

        [Description("You won't get damage when you will be near SCP-244 (false = you won't get damage, true = you will get)")]
        public bool SCP244 { get; set; } = false;
    }
}
