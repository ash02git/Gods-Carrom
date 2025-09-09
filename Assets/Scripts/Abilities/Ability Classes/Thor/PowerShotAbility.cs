using GodsCarrom.Player;
using UnityEngine;

namespace GodsCarrom.Abilites
{
    public class PowerShotAbility : Ability
    {
        private AbilitiesEnum abilityName;

        public PowerShotAbility(PlayerNumber playerNumber, AbilitiesEnum abilityName)
        {
            this.playerNumber = playerNumber;
            castTime = AbilityCastTime.InMove;
            revertTime = AbilityCastTime.PostMove;
            this.abilityName = abilityName;
        }

        public override void OnAbilityCast()
        {
            Debug.Log(abilityName.ToString() + " is cast");
        }

        public override void OnAbilityReverted()
        {
            Debug.Log(abilityName.ToString() + " is reverted");
        }
    }
}