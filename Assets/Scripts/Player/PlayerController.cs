using GodsCarrom.Abilites;
using GodsCarrom.CarromMan;
using GodsCarrom.Formations;
using GodsCarrom.Gods;
using GodsCarrom.Main;
using GodsCarrom.Utilities;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GodsCarrom.Player
{
    public class PlayerController
    {
        private List<CarromManController> carromMen;
        private PlayerNumber playerNumber;

        private CarromManScriptableObject carromSO;

        //private GameObject playerParent;//new line
        private Sprite godSymbol;
        private GodName godName;

        private CarromManController strikingController;
        private Vector2 strikingVelocity;
        public God chosenGod;//player has a reference to god

        public PlayerController(PlayerNumber playerNumber, GodScriptableObject godSO, FormationScriptableObject formationSO, CarromManScriptableObject carromSO, CarromManView carromPrefab)
        {
            this.playerNumber = playerNumber;
            this.godName = godSO.godName;
            this.godSymbol = godSO.godSymbol;
            this.carromSO = carromSO;
            
            carromMen = new List<CarromManController>();
            //CreateCarromMen(formationSO, carromSO, carromPrefab);
            CreateCarromMen(formationSO, godSO, carromSO, carromPrefab);
        }

        private void CreateCarromMen(FormationScriptableObject formationSO, GodScriptableObject godSO, CarromManScriptableObject carromSO, CarromManView carromPrefab)
        {
            foreach (Vector2 position in formationSO.positions)
            {
                CarromManModel carromModel = new CarromManModel(carromSO);

                carromModel.SetOwner(playerNumber);

                //CarromManController newCarromMan = new CarromManController(this, carromModel, carromPrefab);
                //CarromManController newCarromMan = UtilityClass.CreateSpecificCarromMan(this, carromSO, carromPrefab, godSO.godName);
                CarromManController newCarromMan = UtilityClass.CreateSpecificCarromMan(this, carromModel, carromPrefab, godSO.godName);
                newCarromMan.SetSprite(godSymbol);

                if (playerNumber == PlayerNumber.Player1)
                    newCarromMan.SetPosition(position);
                else if (playerNumber == PlayerNumber.Player2)
                    newCarromMan.SetPosition(new Vector2(position.x, -position.y));

                carromMen.Add(newCarromMan);
            }
        }

        public void SetStrikingPiece(CarromManController controller)// => strikingController = controller;
        {
            Debug.Log("Striking piece is set");
            strikingController = controller;
        }

        public void SetStrikingVelocity(Vector3 mousePos, Vector3 position, float aimValue)
        {
            Debug.Log("Aim value is " + aimValue);
            Vector2 forceDirection = position - mousePos;

            strikingVelocity = forceDirection.normalized * aimValue;
        }

        public void StrikeThePiece()
        {
            strikingController.SetVelocity(strikingVelocity); 
        }

        public void SetPlayerNumber(PlayerNumber playerNumber) => this.playerNumber = playerNumber;

        public PlayerNumber GetPlayerNumber() => playerNumber;

        public void CreateCarromMen(FormationScriptableObject formationSO, CarromManScriptableObject carromSO, CarromManView carromPrefab)
        {
            foreach(Vector2 position in formationSO.positions)
            {
                CarromManModel carromModel = new CarromManModel(carromSO);

                carromModel.SetOwner(playerNumber);

                CarromManController newCarromMan = new CarromManController(this, carromModel, carromPrefab);
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
                //CarromManScriptableObject newCarromSO = ScriptableObject.CreateInstance<CarromManScriptableObject>();
                //newCarromSO.CopyFrom(carromSO);

                CarromManModel carromManModel = new CarromManModel(carromSO);
                carromManModel.SetOwner(playerNumber);

                CarromManController newCarromMan = new CarromManController(this, carromManModel, carromPrefab);
                newCarromMan.SetSprite(godSymbol);

                //CarromManController newCarromMan = new CarromManController(this, newCarromSO, carromPrefab);
                //CarromManController newCarromMan = UtilityClass.CreateSpecificCarromMan(this, newCarromSO, carromPrefab, godName);

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

        public void GetAbilityClassAndName(AbilitiesEnum abilityName)
        {
            chosenGod.GetAbilityClassAndName(abilityName);
        }

        public void HideAllPieces()
        {
            foreach(CarromManController carrom in carromMen)
            {
                carrom.HidePiece();
            }
        }

        public void ShowAllPieces()
        {
            foreach(CarromManController carrom in carromMen)
            {
                carrom.ShowPiece();
            }
        }

        public void SpawnCarromMen(int num , CarromManView carromPrefab, float v)
        {
            for (int i = 1; i <= num; i++)
            {
                //CarromManScriptableObject newCarromSO = ScriptableObject.CreateInstance<CarromManScriptableObject>();
                //newCarromSO.CopyFrom(carromSO);

                CarromManModel carromManModel = new CarromManModel(carromSO);
                carromManModel.SetOwner(playerNumber);

                CarromManController newCarromMan = new CarromManController(this, carromManModel, carromPrefab);
                newCarromMan.SetSprite(godSymbol);

                //CarromManController newCarromMan = new CarromManController(this, newCarromSO, carromPrefab);
                //CarromManController newCarromMan = UtilityClass.CreateSpecificCarromMan(this, newCarromSO, carromPrefab, godName);

                carromMen.Add(newCarromMan);

                newCarromMan.SetPosition(GameService.Instance.BoardService.GetRandomPositionFromSpawnArea());
                newCarromMan.SetScale(v);
            }
        }

    }
}