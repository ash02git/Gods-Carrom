using GodsCarrom.Abilites;
using GodsCarrom.Main;
using GodsCarrom.Player;
using System;
using System.Collections;
using UnityEngine;

namespace GodsCarrom.Gameplay
{
    public class Manager : MonoBehaviour
    {
        private GameplayPhase currentPhase;
        private PlayerNumber currentTurn;

        private Coroutine gameLoop;//to store the coroutine of the gameLoop

        [SerializeField] private float moveTime = 4.0f;

        public PlayerNumber GetTurn() => currentTurn;

        public bool phaseOver = false;

        private void Start()
        {
            currentTurn = PlayerNumber.Player1;
            currentPhase = GameplayPhase.AbilitySelectionPhase;

            gameLoop = StartCoroutine(GameLoop());

            GameService.Instance.EventService.OnPhaseCompleted.AddListener(SetNewPhase);
        }

        private void OnDestroy()
        {
            GameService.Instance.EventService.OnPhaseCompleted.RemoveListener(SetNewPhase);
        }

        private IEnumerator GameLoop()
        {
            while(currentTurn != PlayerNumber.None)
            {
                currentTurn = PlayerNumber.Player1;
                Debug.Log("Player 1's turn has started");
                //GameService.Instance.EventService.OnTurnStarted.InvokeEvent(currentTurn);
                currentPhase = GameplayPhase.AbilitySelectionPhase;
                yield return StartCoroutine(HandleTurn(currentTurn));
                Debug.Log("Player 1's turn has ended");

                currentTurn = PlayerNumber.Player2;
                Debug.Log("Player 2's turn has started");
                //GameService.Instance.EventService.OnTurnStarted.InvokeEvent(currentTurn);
                currentPhase = GameplayPhase.AbilitySelectionPhase;
                yield return StartCoroutine(HandleTurn(currentTurn));
                Debug.Log("Player 2's turn has ended");
            }
        }

        private IEnumerator HandleTurn(PlayerNumber playerNumber)
        {
            GameService.Instance.EventService.OnTurnStarted.InvokeEvent(currentTurn);//this is the first thing in a move
            //while (currentPhase != GameplayPhase.TurnCompletedPhase)
            //{
            //    //yield return StartCoroutine(PhaseCoroutine());
            //    yield return StartCoroutine(HandlePhases());
            //}

            yield return StartCoroutine(HandlePhases());
        }

        private IEnumerator PhaseCoroutine()//using a generic approach to each phase, we cannot check the conditions required for specific cases
            //therefore the need might arise to code for each phase's coroutine
        {
            Debug.Log(currentPhase.ToString() + " started");

            GameplayPhase curr = currentPhase;

            PerformBlockerChecks();

            yield return new WaitUntil(() => currentPhase != curr);

            Debug.Log(curr.ToString() + " ended");
        }

        private IEnumerator HandlePhases()
        {
            yield return StartCoroutine(AbilitySelectionPhase());
            //yield return StartCoroutine(AbilityProcessingPhase());

            //check condition for potted

            yield return StartCoroutine(PreMovePhase());
            yield return StartCoroutine(PlayerPhase());
            yield return StartCoroutine(InMovePhase());
            yield return StartCoroutine(PhysicsPhase());
            yield return StartCoroutine(PostMovePhase());
            //yield return StartCoroutine(TurnCompletedPhase()); //maybe add this phase as a delay between each players' turn
        }

        private IEnumerator AbilitySelectionPhase()
        {
            //Debug.Log("Ability Selection Phase started");

            GameService.Instance.UIService.TurnOffAbilityBlocker(currentTurn);

            yield return new WaitUntil(() => phaseOver == true);

            GameService.Instance.UIService.TurnOnAbilityBlocker(currentTurn);
            //Debug.Log("Ability Selection Phase ended");

            phaseOver = false;//resetting phaseOver to false
        }

        private IEnumerator AbilityProcessingPhase()
        {
            Debug.Log("Ability Processing Phase started");
            yield return new WaitUntil(() => phaseOver == true);
            Debug.Log("Ability Processing Phase ended");

            phaseOver = false;
        }

        private IEnumerator PreMovePhase()
        {
            //Debug.Log("PreMove Phase started");

            //GameService.Instance.AbilityService.CheckAndCastAbilityNew(AbilityCastTime.PreMove);
            //GameService.Instance.AbilityService.CheckAndRevertAbilityNew(AbilityCastTime.PreMove);
            GameService.Instance.AbilityService.PerformAbilityUpdates(AbilityCastTime.PreMove);

            yield return new WaitUntil(() => phaseOver == true);

            //Debug.Log("PreMove Phase ended");

            phaseOver = false;
        }

        private IEnumerator PlayerPhase()
        {
            //Debug.Log("Player Phase started");

            GameService.Instance.BoardService.TurnOffBlocker();

            yield return new WaitUntil(() => phaseOver == true);

            GameService.Instance.BoardService.TurnOnBlocker();

            //Debug.Log("Player Phase ended");

            phaseOver = false;
        }

        private IEnumerator InMovePhase()
        {
            //Debug.Log("InMove Phase started");

            //GameService.Instance.AbilityService.CheckAndCastAbilityNew(AbilityCastTime.PreMove);
            //GameService.Instance.AbilityService.CheckAndRevertAbilityNew(AbilityCastTime.PreMove);
            GameService.Instance.AbilityService.PerformAbilityUpdates(AbilityCastTime.InMove);

            yield return new WaitUntil(() => phaseOver == true);

            //Debug.Log("InMove Phase ended");

            phaseOver = false;
        }

        private IEnumerator PhysicsPhase()
        {
            //Debug.Log("Physics Move Phase started");

            //GameService.Instance.AbilityService.CheckAndCastAbilityNew(AbilityCastTime.PreMove);
            //GameService.Instance.AbilityService.CheckAndRevertAbilityNew(AbilityCastTime.PreMove);

            StartCoroutine(MoveTimer());

            yield return new WaitUntil(() => phaseOver == true);

            //Debug.Log("Physics Phase ended");

            phaseOver = false;
        }

        private IEnumerator PostMovePhase()
        {
            //Debug.Log("PostMove Phase started");

            //GameService.Instance.AbilityService.CheckAndCastAbilityNew(AbilityCastTime.PreMove);
            //GameService.Instance.AbilityService.CheckAndRevertAbilityNew(AbilityCastTime.PreMove);
            GameService.Instance.AbilityService.PerformAbilityUpdates(AbilityCastTime.PostMove);

            yield return new WaitUntil(() => phaseOver == true);

            //Debug.Log("PostMove Phase ended");

            phaseOver = false;
        }

        private IEnumerator TurnCompletedPhase()
        {
            Debug.Log("Turn Completed Phase started");

            yield return new WaitUntil(() => phaseOver == true);

            Debug.Log("Turn Completed Phase ended");

            phaseOver = false;
        }

        public void StartMoveTimer() => StartCoroutine(MoveTimer());

        private IEnumerator MoveTimer()
        {
            yield return new WaitForSeconds(moveTime);
            //Debug.Log("Move time is over");
            phaseOver = true;
        }

        private IEnumerator TurnCoroutine()
        {
            yield return null;
        }

        public void SetNewPhase(GameplayPhase newPhase) => currentPhase = newPhase;

        public PlayerNumber GetCurrentTurn() => currentTurn;

        private void PerformBlockerChecks()
        {
            if (currentPhase == GameplayPhase.PlayerPhase)
                GameService.Instance.BoardService.TurnOffBlocker();
            else
                GameService.Instance.BoardService.TurnOnBlocker();

            if(currentPhase == GameplayPhase.AbilitySelectionPhase)
                GameService.Instance.UIService.TurnOffAbilityBlocker(currentTurn);
            else
                GameService.Instance.UIService.TurnOnAbilityBlocker(currentTurn);
        }
    }
}