using GodsCarrom.Main;
using GodsCarrom.Player;
using UnityEngine;

namespace GodsCarrom.Abilites
{
    public class SireDemigodsAbility : Ability //maybe make this premove ability
    {
        public int maxResurrectCount = 2; //can be changed

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

            int currentPiecesCount = GameService.Instance.PlayerService.GetPlayerPieceCount(playerNumber);

            int numOfPiecesToBeResurrected;

            if (currentPiecesCount + maxResurrectCount > 9)
                numOfPiecesToBeResurrected = 9 - currentPiecesCount;
            else
                numOfPiecesToBeResurrected = maxResurrectCount;

            GameService.Instance.PlayerService.SpawnCarromMen(playerNumber, numOfPiecesToBeResurrected, 0.5f);
        }

        public override void OnAbilityReverted()
        {
            Debug.Log(abilityName.ToString() + " is reverted");
            Debug.Log(" Sire Demigods need not be reverted");
        }
    }
}