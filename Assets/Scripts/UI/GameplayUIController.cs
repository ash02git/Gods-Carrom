using System;
using GodsCarrom.Gods;
using GodsCarrom.Main;

namespace GodsCarrom.UI
{
    public class GameplayUIController
    {
        private GameplayUIView gameplayUIView;

        private PlayerUIController player1UIController;
        private PlayerUIController player2UIController;

        public GameplayUIController(GameplayUIView gameplayUIView)
        {
            this.gameplayUIView = gameplayUIView;

            player1UIController = new PlayerUIController(GetPlayer1UIView());
            player2UIController = new PlayerUIController(GetPlayer2UIView());

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            GameService.Instance.EventService.OnGameStarted.AddListener(InitializePlayerUIView);
        }

        private void UnSubscribeToEvents()
        {
            GameService.Instance.EventService.OnGameStarted.RemoveListener(InitializePlayerUIView);
        }

        public PlayerUIView GetPlayer1UIView()
        {
            return gameplayUIView.GetPlayer1UIView();
        }

        public PlayerUIView GetPlayer2UIView()
        {
            return gameplayUIView.GetPlayer2UIView();
        }

        private void InitializePlayerUIView(GodScriptableObject godSO1, GodScriptableObject godSO2)
        {
            player1UIController.SetView(godSO1);
            player2UIController.SetView(godSO2);
        }

        public void InitializePlayersUI(GodScriptableObject p1GodSO, GodScriptableObject p2GodSO)
        {
            player1UIController.SetView(p1GodSO);
            player2UIController.SetView(p2GodSO);
        }
    }
}