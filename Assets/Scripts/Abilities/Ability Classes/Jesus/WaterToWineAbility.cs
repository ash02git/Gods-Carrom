using GodsCarrom.Player;
using UnityEngine;

namespace GodsCarrom.Abilites
{
    public class WaterToWineAbility : Ability
    {
        private AbilitiesEnum abilityName;

        public WaterToWineAbility(PlayerNumber playerNumber, AbilitiesEnum abilityName)
        {
            this.playerNumber = playerNumber;
            castTime = AbilityCastTime.InMove;
            revertTime = AbilityCastTime.None;
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