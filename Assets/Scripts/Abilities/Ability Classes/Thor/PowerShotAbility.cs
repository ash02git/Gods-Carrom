using GodsCarrom.Main;
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
            castTime = AbilityCastTime.PlayerMove;//new ability cast time
            revertTime = AbilityCastTime.PostMove;
            this.abilityName = abilityName;
        }

        public override void OnAbilityCast()
        {
            Debug.Log(abilityName.ToString() + " is cast");
            GameService.Instance.PlayerService.ActivateAbility(playerNumber, AbilitiesEnum.PowerShot);
        }

        public override void OnAbilityReverted()
        {
            Debug.Log(abilityName.ToString() + " is reverted");
            GameService.Instance.PlayerService.DeactivateAbility(playerNumber, AbilitiesEnum.PowerShot);
        }
    }
}