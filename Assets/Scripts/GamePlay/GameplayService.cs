using GodsCarrom.Formations;
using GodsCarrom.Gods;
using GodsCarrom.Main;
using GodsCarrom.Player;
using GodsCarrom.Utilities;
using System.Threading.Tasks;
using UnityEditor.Playables;

namespace GodsCarrom.Gameplay
{
    public class GameplayService
    {
        private PlayerNumber currentTurn;
        private PlayerNumber previousTurn;

        private GameplayScriptableObject gameplaySO;

        public GameplayService(GameplayScriptableObject gameplaySO)
        {
            SetTurn(PlayerNumber.Player1);

            SubscribeToEvents();
            this.gameplaySO = gameplaySO;
        }

        ~GameplayService()
        {
            gameplaySO.p1FormationSO = null;
            gameplaySO.p2FormationSO = null;
        }

        public void SetFormationSOs(FormationEnum p1Formation, FormationEnum p2Formation)
        {
            gameplaySO.p1FormationSO = UtilityClass.GetFormationSO(p1Formation);
            gameplaySO.p2FormationSO = UtilityClass.GetFormationSO(p2Formation);
        }

        public void SetGodSOs(GodName god1, GodName god2)
        {
            gameplaySO.p1GodSO = UtilityClass.GetGodSO(god1);
            gameplaySO.p2GodSO = UtilityClass.GetGodSO(god2);
        }

        public void CreateGameplay()
        {
            GameService.Instance.BoardService.CreateBoard();
            GameService.Instance.HoleService.CreateHoles();
            GameService.Instance.PlayerService.CreatePlayers(gameplaySO.p1FormationSO, gameplaySO.p2FormationSO, gameplaySO.carromSO);
            GameService.Instance.UIService.CreateGameplayUI(gameplaySO.p1GodSO, gameplaySO.p2GodSO);
        }

        private void SubscribeToEvents()
        {
            //GameService.Instance.EventService.OnPointScored.AddListener(CheckGameOver);
        }

        private void CheckGameOver()
        {
            
        }

        private void UnsubscribeToEvents()
        {

        }

        public void SetTurn(PlayerNumber turn)
        {
            previousTurn = currentTurn;
            currentTurn = turn;
        }

        public PlayerNumber GetTurn() => currentTurn;

        private PlayerNumber GetOpponent(PlayerNumber playerTurn)
        {
            if (playerTurn == PlayerNumber.Player1)
                return PlayerNumber.Player2;
            else if (playerTurn == PlayerNumber.Player2)
                return PlayerNumber.Player1;

            return PlayerNumber.None;
        }

        public void StartTimer() => _ = TurnTimer();

        private async Task TurnTimer()
        {
            await Task.Delay(4000);//change this hardCoded value later

            if( !GameService.Instance.HoleService.HasPottedPiece(GetOpponent(previousTurn)))
            {
                if (previousTurn == PlayerNumber.Player1)
                    SetTurn(PlayerNumber.Player2);
                else
                    SetTurn(PlayerNumber.Player1);
            }
            else
            {
                SetTurn(previousTurn);
            }
        }
    }
}