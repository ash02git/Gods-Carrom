using GodsCarrom.Abilites;
using GodsCarrom.Formations;
using GodsCarrom.Gods;
using GodsCarrom.Main;
using GodsCarrom.Player;
using GodsCarrom.Utilities;
using System.Threading.Tasks;

namespace GodsCarrom.Gameplay
{
    public class GameplayService
    {
        private PlayerNumber currentTurn; //to indicate which player is currently playing
        private PlayerNumber previousTurn; // to indicate which player was previously playing

        private AbilityCastTime currentPhase; //change this to PhaseEnum later, used to store current phase of the Move/Turn.

        private GameplayScriptableObject gameplaySO;

        public GameplayService(GameplayScriptableObject gameplaySO)
        {
            //SetTurn(PlayerNumber.Player1);
            currentTurn = PlayerNumber.Player1;
            previousTurn = PlayerNumber.Player2;

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
            GameService.Instance.PlayerService.CreatePlayers(gameplaySO);
            GameService.Instance.UIService.CreateGameplayUI(gameplaySO.p1GodSO, gameplaySO.p2GodSO);
            GameService.Instance.TurnOnManager();
        }

        public void GameLoop()
        {
            //SetTurn(PlayerNumber.Player1);
            //do
            //{

            //} while (true);
            while(true)
            {
                Task a = PhaseTimer();
            }
        }

        private async Task PhaseTimer()
        {
            await Task.Delay(4000); 
        }

        private void SubscribeToEvents()
        {
            //GameService.Instance.EventService.OnPointScored.AddListener(CheckGameOver);
            //GameService.Instance.EventService.OnPhaseCompleted.AddListener(ChangePhase);
            GameService.Instance.EventService.OnMoveCompleted.AddListener(ChangeTurn);
        }

        private void CheckGameOver()
        {
            
        }

        private void UnsubscribeToEvents()
        {
            //GameService.Instance.EventService.OnPhaseCompleted.RemoveListener(ChangePhase);
            GameService.Instance.EventService.OnMoveCompleted.RemoveListener(ChangeTurn);
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

            if( !GameService.Instance.BoardService.HasPottedPiece(GetOpponent(previousTurn)) )
            {
                //if (previousTurn == PlayerNumber.Player1)
                //    SetTurn(PlayerNumber.Player2);
                //else
                //    SetTurn(PlayerNumber.Player1);
                ChangeTurn();
            }
            //else
            //{
            //    SetTurn(previousTurn);
            //}
        }

        private void ChangePhase()
        {
            switch(currentPhase)
            {
                case AbilityCastTime.PreMove:
                    currentPhase = AbilityCastTime.InMove;
                    break;
                case AbilityCastTime.InMove:
                    currentPhase = AbilityCastTime.PostMove;
                    break;
                case AbilityCastTime.PostMove:
                    
                    currentPhase = AbilityCastTime.PreMove;
                    break;
            }
        }

        //Maybe you think again you dumb fool
        //You can have both SetTurn and ChangeTurn
        //SetTurn:- for cases the player pots, ChangeTurn:- for normal flow of play
        private void ChangeTurnNew()
        {
            switch(currentTurn)
            {
                case PlayerNumber.Player1:
                    currentTurn = PlayerNumber.None;
                    break;
                case PlayerNumber.Player2:
                    currentTurn = PlayerNumber.None;
                    break;
                case PlayerNumber.None:
                    currentTurn = PlayerNumber.None;
                    break;
            }
        }

        public void ChangeTurn()
        {
            currentTurn = GetOpponent(currentTurn);
            previousTurn = GetOpponent(currentTurn);
        }
    }
}

//Currently there is a problem 