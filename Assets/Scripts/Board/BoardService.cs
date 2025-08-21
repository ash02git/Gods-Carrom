using System;
using UnityEngine;

namespace GodsCarrom.Board
{
    public class BoardService
    {
        private GameObject boardPrefab;
        private GameObject board;

        public BoardService(GameObject boardPrefab)
        {
            this.boardPrefab = boardPrefab;
        }

        public void CreateBoard()
        {
            board = GameObject.Instantiate(boardPrefab);
        }
    }
}