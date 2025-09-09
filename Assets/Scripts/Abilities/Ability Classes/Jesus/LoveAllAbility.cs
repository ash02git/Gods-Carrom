using GodsCarrom.CarromMan;
using GodsCarrom.Player;
using UnityEngine;

namespace GodsCarrom.Abilites
{
    public class LoveAllAbility : Ability
    {
        private CarromManView carromMan;
        private AbilitiesEnum abilityName;

        public LoveAllAbility(PlayerNumber playerNumber, AbilitiesEnum abilityName)
        {
            this.playerNumber = playerNumber;
            abilityType = AbilityType.AffectingIndividualPiece;
            castTime = AbilityCastTime.PostMove;
            revertTime = AbilityCastTime.PostMove;
            this.abilityName = abilityName;
        }

        public void SetLayer(CarromManController carrom)
        {
            carrom.SetLayer("OnlyBoard");
        }

        public void RevertLayer(CarromManController carrom)
        {
            carrom.SetLayer("Default");
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