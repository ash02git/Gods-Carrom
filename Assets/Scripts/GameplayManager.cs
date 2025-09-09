using GodsCarrom.Abilites;
using GodsCarrom.Gameplay;
using GodsCarrom.Player;
using System.Collections;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private Coroutine phase;
    private Coroutine move;

    //private bool isAbilitySelected;//probably have an enum:- waiting, yes, no
    //also have a method to set it to yes or no so that we can handle the ability
    //if ability is premove- ability,move, inmove - move, at start of move include ability, postmove - move, then do ability.

    private GameplayPeriod gameplayPeriod;

    public IsAbilitySelected isAbilitySelected = IsAbilitySelected.None;
    public PlayerNumber turn;

    public bool isPreMoveAbilitySelected = false;
    public bool isInMoveAbilitySelected = false;
    public bool isPostMoveAbilitySelected = false;


    private void Start()
    {
        StartCoroutine(GameLoop());
    }

    public void ChangeGameplayPeriod(GameplayPeriod gameplayPeriod)
    {
        this.gameplayPeriod = gameplayPeriod;
    }
    
    private IEnumerator GameLoop()
    {
        yield return new WaitUntil(() => gameplayPeriod == GameplayPeriod.PreMovePeriod);
    }

    private IEnumerator GameLoopNew()
    {
        while(true /* game not over*/)
        {
            yield return StartCoroutine(HandlePlayerTurn(PlayerNumber.Player1));
            yield return StartCoroutine(HandlePlayerTurn(PlayerNumber.Player2));
        }
    }

    private IEnumerator HandlePlayerTurn(PlayerNumber playerNumber)
    {
        Debug.Log(playerNumber.ToString() + "turn has started");

        yield return StartCoroutine(AbilitySelectionTimer());

        //execution will continue only after AbilitySelectionTimer()

        if (isPreMoveAbilitySelected)
        {
            yield return StartCoroutine(ApplyPreMoveAbility());
            yield return StartCoroutine(MoveCoroutine());
        }
        else if (isInMoveAbilitySelected)
        {
            yield return StartCoroutine(MoveCoroutine());
        }
        else if(isPostMoveAbilitySelected)
        {
            yield return StartCoroutine(MoveCoroutine());
            yield return StartCoroutine(ApplyPostMoveAbility());
        }

        bool hasSelectedAbility = false;

        if(hasSelectedAbility)
        {
            //HandleAbility();
            //PlayerMove();
        }
        else
        {
            //PlayerMove();
        }

            yield return null;
    }

    private IEnumerator PhaseCoroutine()
    {
        yield return null;
    }

    private IEnumerator MoveCoroutine()
    {
        yield return null;
    }

    private IEnumerator AbilitySelectionTimer()
    {
        yield return new WaitUntil( () => isAbilitySelected == IsAbilitySelected.No || isAbilitySelected == IsAbilitySelected.Yes );

        if(isAbilitySelected == IsAbilitySelected.Yes )
        {
            //check for ability timing
            //then move
        }
        else
        {
            //only move to be done
        }
    }

    private IEnumerator ApplyPreMoveAbility()
    {
        yield return null;
    }

    private IEnumerator ApplyPostMoveAbility()
    {
        yield return null;
    }

    public void SetTurn(PlayerNumber playerNumber) => turn = playerNumber;
}