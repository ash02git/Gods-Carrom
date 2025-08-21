using GodsCarrom.CarromMan;
using GodsCarrom.Formations;
using GodsCarrom.Main;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GodsCarrom.Player
{
    public class PlayerController
    {
        private List<CarromManController> carromMen;
        private PlayerNumber playerNumber;

        private CarromManScriptableObject carromSO;

        private GameObject playerParent;//new line

        public PlayerController(FormationScriptableObject formationSO, PlayerNumber playerNumber, CarromManScriptableObject carromSO, CarromManView carromPrefab) //PlayerScriptableObject pSO
        {
            this.playerNumber = playerNumber;
            carromMen = new List<CarromManController>();
            this.carromSO = carromSO;
            this.carromSO.SetOwner(playerNumber);

            CreateCarromMen(formationSO, this.carromSO, carromPrefab);
        }

        public void SetPlayerNumber(PlayerNumber playerNumber) => this.playerNumber = playerNumber;

        public PlayerNumber GetPlayerNumber() => playerNumber;

        public void CreateCarromMen(FormationScriptableObject formationSO, CarromManScriptableObject carromSO, CarromManView carromPrefab)
        {
            foreach(Vector2 position in formationSO.positions)
            {
                CarromManScriptableObject newCarromSO = ScriptableObject.CreateInstance<CarromManScriptableObject>();
                newCarromSO.CopyFrom(carromSO);

                CarromManController newCarromMan = new CarromManController(this, newCarromSO, carromPrefab);

                if(playerNumber == PlayerNumber.Player1)
                    newCarromMan.SetPosition(position);
                else if(playerNumber == PlayerNumber.Player2)
                    newCarromMan.SetPosition(new Vector2(position.x, -position.y));

                carromMen.Add(newCarromMan);
            }
        }

        public int GetPiecesCount() => carromMen.Count;

        public bool HasPlayerLost()
        {
            if (carromMen.Count <= 0)
                return true;

            return false;
        }

        public void DeleteController(CarromManController carromManController)
        {
            carromMen.Remove(carromManController);
        }

        public void SpawnCarromMen(int numOfPiecesToBeResurrected, CarromManView carromPrefab)
        {
            for(int i=1; i<=numOfPiecesToBeResurrected; i++)
            {
                CarromManScriptableObject newCarromSO = ScriptableObject.CreateInstance<CarromManScriptableObject>();
                newCarromSO.CopyFrom(carromSO);

                CarromManController newCarromMan = new CarromManController(this, newCarromSO, carromPrefab);

                carromMen.Add(newCarromMan);

                newCarromMan.SetPosition(GameService.Instance.BoardService.GetRandomPositionFromSpawnArea());
            }
        }

    }
}