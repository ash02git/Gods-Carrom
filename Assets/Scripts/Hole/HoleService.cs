using GodsCarrom.CarromMan;
using GodsCarrom.Main;
using GodsCarrom.Player;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GodsCarrom.Hole
{
    public class HoleService
    {
        private HoleData holeData;

        private List<HoleView> holes;
        private List<CarromManController> pottedPieces;

        public HoleService(HoleData holeData)
        {
            this.holeData = holeData;
            
            holes = new List<HoleView>();
            pottedPieces = new List<CarromManController>();

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            GameService.Instance.EventService.OnCarromPotted.AddListener(AddToPottedPieces);
        }

        public void CreateHoles()
        {
            foreach(Vector2 position in holeData.holePositions)
                holes.Add( GameObject.Instantiate(holeData.holePrefab, position, Quaternion.identity) );
        }

        private void AddToPottedPieces(CarromManController piece) => pottedPieces.Add(piece);

        public bool HasPottedPiece(PlayerNumber opponent)
        {
            foreach(CarromManController carromMan in  pottedPieces)
            {
                if (carromMan.GetOwner() == opponent)
                {
                    pottedPieces.Clear();
                    return true;
                }
            }
            pottedPieces.Clear();
            return false;
        }

    }
}