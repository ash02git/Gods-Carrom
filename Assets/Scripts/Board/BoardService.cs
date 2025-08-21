using GodsCarrom.CarromMan;
using GodsCarrom.Hole;
using GodsCarrom.Main;
using GodsCarrom.Player;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace GodsCarrom.Board
{
    public class BoardService
    {
        //preset data
        private GameObject boardPrefab;
        private HoleView holePrefab;
        private HoleData holeData;

        //service related data
        private GameObject board;
        private PolygonCollider2D collider;
        private List<HoleView> holes;
        private List<CarromManController> pottedPieces;

        public BoardService(GameObject boardPrefab,HoleView holePrefab, HoleData holeData)
        {
            this.boardPrefab = boardPrefab;
            this.holePrefab = holePrefab;
            this.holeData = holeData;

            holes = new List<HoleView>();
            pottedPieces = new List<CarromManController>();

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            GameService.Instance.EventService.OnCarromPotted.AddListener(AddToPottedPieces);
        }

        private void AddToPottedPieces(CarromManController piece) => pottedPieces.Add(piece);

        public void CreateBoard()
        {
            board = GameObject.Instantiate(boardPrefab);
            collider = board.GetComponentInChildren<PolygonCollider2D>();

            CreateHoles();
        }

        public void CreateHoles()
        {
            foreach(Vector2 position in holeData.holePositions)
            {
                HoleView newHole = GameObject.Instantiate(holePrefab);
                newHole.transform.position = position;

                holes.Add(newHole);
            }
        }

        public bool HasPottedPiece(PlayerNumber opponent)
        {
            foreach (CarromManController carromMan in pottedPieces)
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

        public Vector2 GetRandomPositionFromSpawnArea()
        {
            Bounds bounds = collider.bounds;
            Vector2 point;

            do
            {
                float x = Random.Range(bounds.min.x, bounds.max.x);
                float y = Random.Range(bounds.min.y, bounds.max.y);
                point = new Vector2(x, y);
            }
            while (!collider.OverlapPoint(point));

            return point;
        }
    }
}