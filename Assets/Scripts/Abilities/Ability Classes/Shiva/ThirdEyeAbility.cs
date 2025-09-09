using GodsCarrom.Player;
using UnityEngine;

namespace GodsCarrom.Abilites
{
    public class ThirdEyeAbility : Ability //maybe make this premove ability
    {
        private AbilitiesEnum abilityName;

        public ThirdEyeAbility(PlayerNumber playerNumber, AbilitiesEnum abilityName)
        {
            this.playerNumber = playerNumber;
            castTime = AbilityCastTime.PreMove;
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