using GodsCarrom.CarromMan;
using GodsCarrom.Formations;
using GodsCarrom.Main;
using System.Collections.Generic;
using UnityEngine;

namespace GodsCarrom.Player
{
    public class PlayerController
    {
        private List<CarromManController> carromMen;
        private PlayerNumber playerNumber;

        private GameObject playerParent;//new line

        public PlayerController(FormationScriptableObject formationSO, PlayerNumber playerNumber, CarromManScriptableObject carromSO) //PlayerScriptableObject pSO
        {
            this.playerNumber = playerNumber;
            carromMen = new List<CarromManController>();
            //playerParent = new GameObject();//new line

            CreateCarromMen(formationSO, carromSO);
        }

        public void SetPlayerNumber(PlayerNumber playerNumber) => this.playerNumber = playerNumber;

        public PlayerNumber GetPlayerNumber() => playerNumber;

        public void CreateCarromMen(FormationScriptableObject formationSO, CarromManScriptableObject carromSO)
        {
            carromMen = GameService.Instance.CarromMenService.CreateCarromMen(this, formationSO);
        }

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
    }
}