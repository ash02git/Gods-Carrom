using GodsCarrom.Main;
using TMPro;
using UnityEngine;

public class TurnTextView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI turnText;
    private void FixedUpdate()
    {
        //turnText.text = "TURN : " + GameService.Instance.gameManager.GetCurrentTurn();
        turnText.text = "TURN : " + GameService.Instance.GameplayService.GetCurrentTurn();
    }
}
