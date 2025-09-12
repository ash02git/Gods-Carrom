using GodsCarrom.CarromMan;
using GodsCarrom.Main;
using GodsCarrom.Player;
using GodsCarrom.Utilities;
using System;
using UnityEngine;

namespace GodsCarrom.Abilites
{
    [Serializable]
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

        public override void OnAbilityCast()
        {
            Debug.Log(abilityName.ToString() + " is cast");
            GameService.Instance.PlayerService.ChangeLayerOfPieces(UtilityClass.GetOpponent(playerNumber), "OnlyBoard");
        }

        public override void OnAbilityReverted()
        {
            Debug.Log(abilityName.ToString() + " is reverted");
            GameService.Instance.PlayerService.ChangeLayerOfPieces(UtilityClass.GetOpponent(playerNumber), "Pieces");
        }
    }
}