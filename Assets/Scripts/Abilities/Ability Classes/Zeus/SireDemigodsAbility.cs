using GodsCarrom.Player;
using UnityEngine;

namespace GodsCarrom.Abilites
{
    public class SireDemigodsAbility : Ability //maybe make this premove ability
    {
        private AbilitiesEnum abilityName;

        public SireDemigodsAbility(PlayerNumber playerNumber, AbilitiesEnum abilityName)
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