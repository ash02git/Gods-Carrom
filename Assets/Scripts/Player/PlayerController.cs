using GodsCarrom.Abilites;
using GodsCarrom.CarromMan;
using GodsCarrom.Formations;
using GodsCarrom.Gods;
using GodsCarrom.Main;
using GodsCarrom.Utilities;
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
        private Sprite godSymbol;
        private GodName godName;

        private CarromManController strikingController;

        public PlayerController(GodName godName, Sprite godSymbol, FormationScriptableObject formationSO, PlayerNumber playerNumber, CarromManScriptableObject carromSO, CarromManView carromPrefab) //PlayerScriptableObject pSO
        {
            this.playerNumber = playerNumber;
            this.godName = godName;
            this.godSymbol = godSymbol;
            carromMen = new List<CarromManController>();
            this.carromSO = carromSO;
            this.carromSO.SetOwner(playerNumber);

            CreateCarromMen(formationSO, this.carromSO, carromPrefab);
        }

        public void SetStrikingPiece(CarromManController controller)// => strikingController = controller;
        {
            Debug.Log("Striking piece is set");
            strikingController = controller;
        }

        public void SetPlayerNumber(PlayerNumber playerNumber) => this.playerNumber = playerNumber;

        public PlayerNumber GetPlayerNumber() => playerNumber;

        public void CreateCarromMen(FormationScriptableObject formationSO, CarromManScriptableObject carromSO, CarromManView carromPrefab)
        {
            foreach(Vector2 position in formationSO.positions)
            {
                CarromManScriptableObject newCarromSO = ScriptableObject.CreateInstance<CarromManScriptableObject>();
                newCarromSO.CopyFrom(carromSO);

                //CarromManController newCarromMan = new CarromManController(this, newCarromSO, carromPrefab);
                //newCarromMan.SetSprite(godSymbol);

                CarromManController newCarromMan = UtilityClass.CreateSpecificCarromMan(this, newCarromSO, carromPrefab, godName);
                newCarromMan.SetSprite(godSymbol);

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

        public void SpawnCarromMen(int num, CarromManView carromPrefab)
        {
            for(int i=1; i<=num; i++)
            {
                CarromManScriptableObject newCarromSO = ScriptableObject.CreateInstance<CarromManScriptableObject>();
                newCarromSO.CopyFrom(carromSO);

                //CarromManController newCarromMan = new CarromManController(this, newCarromSO, carromPrefab);
                CarromManController newCarromMan = UtilityClass.CreateSpecificCarromMan(this, newCarromSO, carromPrefab, godName);

                carromMen.Add(newCarromMan);

                newCarromMan.SetPosition(GameService.Instance.BoardService.GetRandomPositionFromSpawnArea());
            }
        }

        public void ActivateAbility(AbilitiesEnum abilityName)
        {
            //set for the particular carrommancontroller
            strikingController.ActivateAbility(abilityName);
        }

        public void AddPiece(CarromManController collidedController)
        {
            carromMen.Add(collidedController);
            collidedController.SetSprite(godSymbol);
        }

        public void RemovePiece(CarromManController collidedController)
        {
            carromMen.Remove(collidedController);
        }

        public void DeactivateAbility(AbilitiesEnum abilityName)
        {
            strikingController.DeactivateAbility(abilityName);
        }

        public void ChangeLayerOfPieces(string v)
        {
            foreach(CarromManController c in  carromMen)
            {
                c.SetLayer(v);
            }
        }
    }
}