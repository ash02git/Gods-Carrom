using UnityEngine;

namespace GodsCarrom.UI
{
    public class GameplayUIView : MonoBehaviour
    {
        private GameplayUIController controller;

        [SerializeField] private PlayerUIView player1UIView;
        [SerializeField] private PlayerUIView player2UIView;

        public void SetController(GameplayUIController controller) => this.controller = controller;

        public PlayerUIView GetPlayer1UIView()
        {
            return player1UIView;
        }

        public PlayerUIView GetPlayer2UIView()
        {
            return player2UIView;
        }
    }
}