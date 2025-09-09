using GodsCarrom.Player;
using System;

namespace GodsCarrom.Abilites
{
    [Serializable]
    public struct AbilityDetails
    {
        private PlayerNumber playerNumber;
        public AbilitiesEnum abilityName;
        public AbilityCastTime castTime;
        public AbilityCastTime revertTime;

        public void SetPlayerNumber(PlayerNumber playerNumber) => this.playerNumber = playerNumber;

        public PlayerNumber GetPlayerNumber() => playerNumber;
    }
}