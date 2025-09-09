using GodsCarrom.Player;
using UnityEngine;

namespace GodsCarrom.Abilites
{
    public class TradeDeathAbility : Ability
    {
        private AbilitiesEnum abilityName;

        public TradeDeathAbility(PlayerNumber playerNumber, AbilitiesEnum abilityName)
        {
            this.playerNumber = playerNumber;
            castTime = AbilityCastTime.InMove;
            revertTime = AbilityCastTime.None;//this ability doesnt have to revert
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