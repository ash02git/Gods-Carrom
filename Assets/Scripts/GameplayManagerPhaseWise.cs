using GodsCarrom.Abilites;
using GodsCarrom.Player;
using System.Collections;
using UnityEngine;

public class GameplayManagerPhaseWise : MonoBehaviour
{
    private IsAbilitySelected isAbilitySelected = IsAbilitySelected.None;
    private AbilityCastTime selectedAbilityCastTime = AbilityCastTime.None;
    private bool hasPlayerMoved = false;

    public void SetAbilitySelected(IsAbilitySelected value) => isAbilitySelected = value;

    public void SetAbilityCastTime(AbilityCastTime value) => selectedAbilityCastTime = value;

    public void OnPlayerMadeMove() => hasPlayerMoved = true;


    public void StartTheGame() => StartCoroutine(GameLoop());

    private IEnumerator GameLoop()
    {
        while(true)
        {
            yield return StartCoroutine(HandlePlayerTurn(PlayerNumber.Player1));
            yield return StartCoroutine(HandlePlayerTurn(PlayerNumber.Player2));
        }
    }

    private IEnumerator HandlePlayerTurn(PlayerNumber player1)
    {
        yield return StartCoroutine(AbilitySelectionPhase());
        //yield return StartCoroutine(PreMovePhase());
        //yield return StartCoroutine(PlayerPhase());
        //yield return StartCoroutine(InMovePhase());
        //yield return StartCoroutine(PostMovePhase());
    }

    private IEnumerator AbilitySelectionPhase()
    {
        yield return new WaitUntil(() => isAbilitySelected == IsAbilitySelected.Yes || isAbilitySelected == IsAbilitySelected.No);
    }

}
