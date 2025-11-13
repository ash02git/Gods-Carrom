using GodsCarrom.Abilites;
using GodsCarrom.Formations;
using GodsCarrom.Gods;
using GodsCarrom.Main;
using GodsCarrom.Player;
using GodsCarrom.Utilities;
using System.Collections;
using UnityEngine;

namespace GodsCarrom.Gameplay
{
    public class GameplayServiceNew : MonoBehaviour
    {
        [SerializeField] private GameplayScriptableObject gameplaySO;
        [SerializeField] private float moveTime = 4.0f;

        private GameplayPhase currentPhase;
        private PlayerNumber currentTurn;

        public bool phaseOver = false; //later make it private and add a public setter

        private void Start()
        {
            currentTurn = PlayerNumber.Player1;
            currentPhase = GameplayPhase.AbilitySelectionPhase;

            GameService.Instance.EventService.OnPhaseCompleted.AddListener(SetNewPhase);
        }

        private void OnDestroy()
        {
            GameService.Instance.EventService.OnPhaseCompleted.RemoveListener(SetNewPhase);
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

            StartCoroutine(GameLoop());
        }

        public void DestroyGameplay()
        {
            //GameService.Instance.BoardService.Cleanup();
            //GameService.Instance.PlayerService.Cleanup();
            //GameService.Instance.UIService.CleanupGameplayUI();
        }

        public PlayerNumber GetCurrentTurn() => currentTurn;

        private IEnumerator GameLoop()
        {
            Debug.Log("Started game loop");
            while (currentTurn != PlayerNumber.None) //later replace this condition with if game is not over
            {
                currentTurn = PlayerNumber.Player1;
                Debug.Log("Player 1's turn has started");

                currentPhase = GameplayPhase.AbilitySelectionPhase;//setting up the first phase
                yield return StartCoroutine(HandleTurn(currentTurn));

                Debug.Log("Player 1's turn has ended");

                currentTurn = PlayerNumber.Player2;
                Debug.Log("Player 2's turn has started");

                currentPhase = GameplayPhase.AbilitySelectionPhase;//setting up the first phase
                yield return StartCoroutine(HandleTurn(currentTurn));

                Debug.Log("Player 2's turn has ended");
            }
        }

        private IEnumerator HandleTurn(PlayerNumber playerNumber)
        {
            //below line invokes event which turns on Ability Selection Timer
            GameService.Instance.EventService.OnTurnStarted.InvokeEvent(currentTurn);//this is the first thing in a move
            
            yield return StartCoroutine(HandlePhases());
        }

        private IEnumerator HandlePhases()
        {
            yield return StartCoroutine(AbilitySelectionPhase());
            yield return StartCoroutine(PreMovePhase());
            yield return StartCoroutine(PlayerPhase());
            yield return StartCoroutine(InMovePhase());
            yield return StartCoroutine(PhysicsPhase());
            yield return StartCoroutine(PostMovePhase());
            //yield return StartCoroutine(TurnCompletedPhase()); //maybe add this phase as a delay between each players' turn
        }


        private IEnumerator AbilitySelectionPhase()
        {
            Debug.Log("Ability Selection phase has started");
            
            GameService.Instance.UIService.TurnOffAbilityBlocker(currentTurn);//turning off the blocker for abilitySelectionUI

            yield return new WaitUntil(() => phaseOver == true);

            GameService.Instance.UIService.TurnOnAbilityBlocker(currentTurn);//turning on the blocker for abilitySelectionUI

            Debug.Log("Ability Selection phase has ended");

            phaseOver = false;//resetting phaseOver to false, can make this as a function later
        }

        private IEnumerator PreMovePhase()
        {

            Debug.Log("Pre move phase has started");

            GameService.Instance.AbilityService.PerformAbilityUpdates(AbilityCastTime.PreMove);// checks if any ability needs to reverted or casted

            yield return new WaitUntil(() => phaseOver == true);

            Debug.Log("PreMove phase has ended");

            phaseOver = false;
        }

        private IEnumerator PlayerPhase() //maybe rename to input phase
        {
            Debug.Log("Player Phase has started");
            
            GameService.Instance.BoardService.TurnOffBlocker();//turns off BoardBlocker so that player can give input to the pieces

            yield return new WaitUntil(() => phaseOver == true);

            GameService.Instance.BoardService.TurnOnBlocker();//turns on BoardBlocker so that player can give input to the pieces

            Debug.Log("Player Phase has ended");

            phaseOver = false;
        }

        private IEnumerator InMovePhase()//done just before the piece moves.
        {
            Debug.Log("InMove Phase has started");

            GameService.Instance.AbilityService.PerformAbilityUpdates(AbilityCastTime.InMove);// checks if any ability needs to reverted or casted - commented for now
            //GameService.Instance.PlayerService.StrikePiece(currentTurn);
            //StartCoroutine(MoveTimer());

            yield return new WaitUntil(() => phaseOver == true);

            Debug.Log("InMove phase has ended");

            phaseOver = false;
        }

        private IEnumerator PhysicsPhase()//the phase where the piece moves
        {
            Debug.Log("Physics phase has started");
            
            

            GameService.Instance.PlayerService.StrikePiece(currentTurn);

            StartCoroutine(MoveTimer()); 

            //GameService.Instance.AbilityService.PerformAbilityUpdates(AbilityCastTime.PhysicsMove);// checks if any ability needs to reverted or casted

            yield return new WaitUntil(() => phaseOver == true);

            Debug.Log("Physics phase has ended");

            phaseOver = false;
        }

        private IEnumerator PostMovePhase()//the phase after the pieces have moved
        {
            Debug.Log("PostMove phase has started");

            GameService.Instance.AbilityService.PerformAbilityUpdates(AbilityCastTime.PostMove);

            yield return new WaitUntil(() => phaseOver == true);

            Debug.Log("PostMove phase has ended");

            phaseOver = false;
        }

        private IEnumerator MoveTimer()
        {
            yield return new WaitForSeconds(moveTime);
            phaseOver = true;
        }

        public void SetNewPhase(GameplayPhase newPhase) => currentPhase = newPhase;

        private void PerformBlockerChecks()
        {
            if (currentPhase == GameplayPhase.PlayerPhase)
                GameService.Instance.BoardService.TurnOffBlocker();
            else
                GameService.Instance.BoardService.TurnOnBlocker();

            if (currentPhase == GameplayPhase.AbilitySelectionPhase)
                GameService.Instance.UIService.TurnOffAbilityBlocker(currentTurn);
            else
                GameService.Instance.UIService.TurnOnAbilityBlocker(currentTurn);
        }
    }
}