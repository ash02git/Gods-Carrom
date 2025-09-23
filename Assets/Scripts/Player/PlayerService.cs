using GodsCarrom.Abilites;
using GodsCarrom.CarromMan;
using GodsCarrom.Gameplay;
using GodsCarrom.Main;
using System;
using UnityEngine;

namespace GodsCarrom.Player
{
    public class PlayerService
    {
        //references of PlayerControllers
        private PlayerController player1controller;
        private PlayerController player2controller;

        //reference to Carrom Man Prefab
        private CarromManView carromPrefab;

        public PlayerService(CarromManView carromPrefab)
        {
            SubscribeToEvents();
            this.carromPrefab = carromPrefab;
        }

        ~PlayerService()
        {
            player1controller = null;
            player2controller = null;
        }

        private void SubscribeToEvents()
        {
            GameService.Instance.EventService.OnPointScored.AddListener(CheckGameOver);
        }

        private void CheckGameOver()
        {
            if(player1controller.HasPlayerLost())
            {
                Debug.Log("Player 1 has Lost");
            }
            
            if(player2controller.HasPlayerLost())
            {
                Debug.Log("Player 2 has Lost");
            }
        }

        public void CreatePlayers(GameplayScriptableObject gameplaySO)
        {
            player1controller = new PlayerController(gameplaySO.p1GodSO.godName, gameplaySO.p1GodSO.godSymbol, gameplaySO.p1FormationSO, PlayerNumber.Player1, gameplaySO.carromSO, carromPrefab);
            player2controller = new PlayerController(gameplaySO.p2GodSO.godName, gameplaySO.p2GodSO.godSymbol, gameplaySO.p2FormationSO, PlayerNumber.Player2, gameplaySO.carromSO, carromPrefab);

            player1controller = new PlayerController(PlayerNumber.Player1 ,gameplaySO.p1GodSO, gameplaySO.p1FormationSO, gameplaySO.carromSO, carromPrefab);
            player2controller = new PlayerController(PlayerNumber.Player2, gameplaySO.p2GodSO, gameplaySO.p2FormationSO, gameplaySO.carromSO, carromPrefab);
        }

        public void SpawnCarromMen(PlayerNumber playerNumber, int numOfPiecesToBeResurrected)
        {
            if (playerNumber == PlayerNumber.Player1)
                player1controller.SpawnCarromMen(numOfPiecesToBeResurrected, carromPrefab);
            else if (playerNumber == PlayerNumber.Player2)
                player1controller.SpawnCarromMen(numOfPiecesToBeResurrected, carromPrefab);
        }

        public int GetPlayerPieceCount(PlayerNumber playerNumber)
        {
            if (playerNumber == PlayerNumber.Player1)
                return player1controller.GetPiecesCount();
            else if (playerNumber == PlayerNumber.Player2)
                return player2controller.GetPiecesCount();
            else
                return -1;
        }

        public void ActivateAbility(PlayerNumber playerNumber, AbilitiesEnum abilityName)
        {
            if (playerNumber == PlayerNumber.Player1)
                player1controller.ActivateAbility(abilityName);
            else if(playerNumber == PlayerNumber.Player2)
                player2controller.ActivateAbility(abilityName);
        }

        public void DeactivateAbility(PlayerNumber playerNumber, AbilitiesEnum abilityName)
        {
            if (playerNumber == PlayerNumber.Player1)
                player1controller.DeactivateAbility(abilityName);
            else if (playerNumber == PlayerNumber.Player2)
                player2controller.DeactivateAbility(abilityName);
        }

        public void ChangeLayerOfPieces(PlayerNumber playerNumber, string v)
        {
            if (playerNumber == PlayerNumber.Player1)
                player1controller.ChangeLayerOfPieces(v);
            else if (playerNumber == PlayerNumber.Player2)
                player2controller.ChangeLayerOfPieces(v);
        }

        //public AbilityNameAndClass GetAbilityClassAndName(PlayerNumber playerNumber, AbilitiesEnum abilityName)
        //{
        //    if (playerNumber == PlayerNumber.Player1)
        //        player1controller.GetAbilityClassAndName(abilityName);
        //    else if (playerNumber == PlayerNumber.Player2)
        //        player2controller.GetAbilityClassAndName(abilityName);
        //}
    }
}