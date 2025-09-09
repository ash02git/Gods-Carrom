using GodsCarrom.Gods;
using GodsCarrom.Main;
using GodsCarrom.Player;
using System;

namespace GodsCarrom.UI
{
    public class GameplayUIController
    {
        private GameplayUIView gameplayUIView;

        private PlayerUIController player1UIController;
        private PlayerUIController player2UIController;

        public GameplayUIController(GameplayUIView gameplayUIView, AbilityButtonView abilityButtonPrefab)
        {
            this.gameplayUIView = gameplayUIView;

            player1UIController = new PlayerUIController(PlayerNumber.Player1 ,GetPlayer1UIView(), abilityButtonPrefab);
            player2UIController = new PlayerUIController(PlayerNumber.Player2, GetPlayer2UIView(), abilityButtonPrefab);

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            GameService.Instance.EventService.OnGameStarted.AddListener(InitializePlayersUIView);
        }

        private void UnSubscribeToEvents()
        {
            GameService.Instance.EventService.OnGameStarted.RemoveListener(InitializePlayersUIView);
        }

        public PlayerUIView GetPlayer1UIView()
        {
            return gameplayUIView.GetPlayer1UIView();
        }

        public PlayerUIView GetPlayer2UIView()
        {
            return gameplayUIView.GetPlayer2UIView();
        }

        public void InitializePlayersUIView(GodScriptableObject godSO1, GodScriptableObject godSO2)
        {
            player1UIController.InitializeView(godSO1);
            player2UIController.InitializeView(godSO2);
        }

        public void TurnOnAbilityBlocker(PlayerNumber currentTurn)
        {
            if (currentTurn == PlayerNumber.Player1)
                player1UIController.TurnOnAbilityBlocker();
            else if(currentTurn == PlayerNumber.Player2)
                player2UIController.TurnOnAbilityBlocker();
        }

        public void TurnOffAbilityBlocker(PlayerNumber currentTurn)
        {
            if (currentTurn == PlayerNumber.Player1)
                player1UIController.TurnOffAbilityBlocker();
            else if (currentTurn == PlayerNumber.Player2)
                player2UIController.TurnOffAbilityBlocker();
        }

    }
}