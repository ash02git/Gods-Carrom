using GodsCarrom.Formations;
using GodsCarrom.Player;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GodsCarrom.CarromMan
{
    public class CarromMenService
    {
        private CarromManView carromManPrefab;
        private CarromManScriptableObject carromSO;
        private List<CarromManController> carroms;

        public CarromMenService(CarromManView carromManPrefab, CarromManScriptableObject carromSO)
        {
            carroms = new List<CarromManController>();
            this.carromManPrefab = carromManPrefab;
            this.carromSO = carromSO;
        }

        public List<CarromManController> CreateCarromMen(PlayerController Owner, FormationScriptableObject formationSO)
        {
            List<CarromManController> carromMenList = new List<CarromManController>();

            foreach(Vector2 position in formationSO.positions)
            {
                CarromManScriptableObject newCarromSO = ScriptableObject.CreateInstance<CarromManScriptableObject>();
                newCarromSO.CopyFrom(carromSO);

                //CarromManController newCarromMan = new CarromManController(Owner, newCarromSO);

                if (Owner.GetPlayerNumber() == PlayerNumber.Player1)
                {
                    //newCarromMan.SetPosition(position);
                }
                else
                {
                    //newCarromMan.SetPosition(new Vector2(position.x, -position.y));
                }

                //carroms.Add(newCarromMan);
                //carromMenList.Add(newCarromMan);
            }

            return carromMenList;
        }

        public int GetPiecesCount(PlayerNumber playerNumber)
        {
            int pieceCount = 0;
            
            foreach(CarromManController carromMan in carroms)
            {
                if (carromMan.GetOwner() == playerNumber)
                    pieceCount++;
            }

            return pieceCount;
        }

        public void CreateCarromMen(PlayerNumber playerNumber, int numOfPiecesToBeResurrected)
        {
            for(int i=0; i< numOfPiecesToBeResurrected; i++)
            {
                CarromManScriptableObject newCarromSO = ScriptableObject.CreateInstance<CarromManScriptableObject>();
                newCarromSO.CopyFrom(carromSO);

                //CarromManController newCarromMan = new CarromManController(playerNumber, newCarromSO, carromManPrefab);
            }
        }
    }
}