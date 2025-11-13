using GodsCarrom.Main;
using GodsCarrom.Player;
using System.Collections;
using UnityEngine;

namespace GodsCarrom.Abilites
{
    public class DistortAbility : Ability //maybe make this premove ability
    {
        private AbilitiesEnum abilityName;

        public DistortAbility(PlayerNumber playerNumber, AbilitiesEnum abilityName)
        {
            this.playerNumber = playerNumber;
            castTime = AbilityCastTime.PostMove;
            revertTime = AbilityCastTime.PostMove;
            this.abilityName = abilityName;
        }

        public override void OnAbilityCast()
        {
            Debug.Log(abilityName.ToString() + " is cast");
            GameService.Instance.CameraService.PlayDistortAnim();
        }

        public override void OnAbilityReverted()
        {
            Debug.Log(abilityName.ToString() + " is reverted");
            GameService.Instance.CameraService.RevertDistortAnim();
        }

        IEnumerator AnimationWaitTimer()
        {
            yield return new WaitForSeconds(2.0f);

        }
    }
}