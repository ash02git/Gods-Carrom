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

        public void HideAllPieces(PlayerNumber playerNumber)
        {
            if (playerNumber == PlayerNumber.Player1)
                player1controller.HideAllPieces();
            else if (playerNumber == PlayerNumber.Player2)
                player2controller.HideAllPieces();
        }

        public void ShowAllPieces(PlayerNumber playerNumber)
        {
            if (playerNumber == PlayerNumber.Player1)
                player1controller.ShowAllPieces();
            else if (playerNumber == PlayerNumber.Player2)
                player2controller.ShowAllPieces();
        }

        public void SpawnCarromMen(PlayerNumber playerNumber, int numOfPiecesToBeResurrected, float v)
        {
            if (playerNumber == PlayerNumber.Player1)
                player1controller.SpawnCarromMen(numOfPiecesToBeResurrected, carromPrefab, v);
            else if (playerNumber == PlayerNumber.Player2)
                player1controller.SpawnCarromMen(numOfPiecesToBeResurrected, carromPrefab, v);
        }

        //public AbilityNameAndClass GetAbilityClassAndName(PlayerNumber playerNumber, AbilitiesEnum abilityName)
        //{
        //    if (playerNumber == PlayerNumber.Player1)
        //        player1controller.GetAbilityClassAndName(abilityName);
        //    else if (playerNumber == PlayerNumber.Player2)
        //        player2controller.GetAbilityClassAndName(abilityName);
        //}

        public void StrikePiece(PlayerNumber playerNumber)
        {
            if (playerNumber == PlayerNumber.Player1)
                player1controller.StrikeThePiece();
            else if (playerNumber == PlayerNumber.Player2)
                player2controller.StrikeThePiece();

        }
    }
}