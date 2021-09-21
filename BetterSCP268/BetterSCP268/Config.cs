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
        public string bc { get; set; } = "<color=#ffe500> A player with SCP-268 next to you </color>";

        [Description("How long will show broadcast")]
        public int bctime { get; set; } = 10;

        [Description("Tesla will be disabled if SCP-268 goes through the tesla")]
        public bool tesla { get; set; } = true;

        [Description("SCP-096 can't see if player uses SCP-268")]
        public bool scp096 { get; set; } = true;

        [Description("The distance between players from which the broadcast will show")]
        public int dis { get; set; } = 16;

        [Description("Will Player with SCP-268 be flashed or no?")]
        public bool flashed { get; set; } = true;
    }
}
