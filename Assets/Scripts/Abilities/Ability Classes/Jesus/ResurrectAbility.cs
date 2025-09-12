using GodsCarrom.Player;
using UnityEngine;
using GodsCarrom.Main;

namespace GodsCarrom.Abilites
{
    public class ResurrectAbility : Ability
    {
        public int maxResurrectCount = 2; //can be changed
        private AbilitiesEnum abilityName;

        public ResurrectAbility(PlayerNumber playerNumber, AbilitiesEnum abilityName)
        {
            this.playerNumber = playerNumber;
            abilityType = AbilityType.AffectingPieceCount;
            castTime = AbilityCastTime.PreMove;
            revertTime = AbilityCastTime.None;
            this.abilityName = abilityName;
        }

        public override void OnAbilityCast()
        {
            Debug.Log(abilityName.ToString() + " is cast");

            int currentPiecesCount = GameService.Instance.PlayerService.GetPlayerPieceCount(playerNumber);

            int numOfPiecesToBeResurrected;

            if (currentPiecesCount + maxResurrectCount > 9)
                numOfPiecesToBeResurrected = 9 - currentPiecesCount;
            else
                numOfPiecesToBeResurrected = maxResurrectCount;

            GameService.Instance.PlayerService.SpawnCarromMen(playerNumber, numOfPiecesToBeResurrected);
        }

        public override void OnAbilityReverted()// nothing to revert for a premove ability
        {
            Debug.Log(abilityName.ToString() + " is reverted");
        }
    }
}