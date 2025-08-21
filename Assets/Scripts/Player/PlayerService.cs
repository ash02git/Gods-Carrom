using GodsCarrom.CarromMan;
using GodsCarrom.Formations;
using GodsCarrom.Main;
using System;
using UnityEngine;

namespace GodsCarrom.Player
{
    public class PlayerService
    {
        private PlayerController player1controller;
        private PlayerController player2controller;

        private CarromManView carromPrefab;

        public PlayerService(PlayerScriptableObject p1SO, PlayerScriptableObject p2SO, CarromManView carromPrefab)
        {
            SubscribeToEvents();
            this.carromPrefab = carromPrefab;
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

        public void CreatePlayers(FormationScriptableObject p1FormationSO, FormationScriptableObject p2FormationSO, CarromManScriptableObject carromSO)
        {
            player1controller = new PlayerController(p1FormationSO, PlayerNumber.Player1, carromSO, carromPrefab);
            player2controller = new PlayerController(p2FormationSO, PlayerNumber.Player2, carromSO, carromPrefab);
        }

        public void SpawnCarromMen(PlayerNumber playerNumber, int numOfPiecesToBeResurrected)
        {
            if (playerNumber == PlayerNumber.Player1)
                player1controller.SpawnCarromMen(numOfPiecesToBeResurrected, carromPrefab);
            else if (playerNumber == PlayerNumber.Player2)
                player1controller.SpawnCarromMen(numOfPiecesToBeResurrected, carromPrefab);
        }
    }
}