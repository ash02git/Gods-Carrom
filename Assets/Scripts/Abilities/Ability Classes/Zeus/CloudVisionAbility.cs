using GodsCarrom.Main;
using GodsCarrom.Player;
using UnityEngine;

namespace GodsCarrom.Abilites
{
    public class CloudVisionAbility : Ability //maybe make this premove ability
    {
        private AbilitiesEnum abilityName;

        public CloudVisionAbility(PlayerNumber playerNumber, AbilitiesEnum abilityName)
        {
            this.playerNumber = playerNumber;
            castTime = AbilityCastTime.PostMove;
            revertTime = AbilityCastTime.PostMove;
            this.abilityName = abilityName;
        }

        public override void OnAbilityCast()
        {
            Debug.Log(abilityName.ToString() + " is cast");
            GameService.Instance.BoardService.TurnOnObstructor();
        }

        public override void OnAbilityReverted()
        {
            Debug.Log(abilityName.ToString() + " is reverted");
            GameService.Instance.BoardService.TurnOffObstructor();
        }
    }
}