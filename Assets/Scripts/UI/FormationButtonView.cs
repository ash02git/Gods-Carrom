using GodsCarrom.Formations;
using GodsCarrom.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsCarrom.UI
{
    public class FormationButtonView : MonoBehaviour
    {
        private PlayerNumber playerNumber;
        private FormationEnum formation;
        [SerializeField] private TextMeshProUGUI buttonText;

        private FormationSelectionUIController Owner;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnFormationButtonClicked);
        }

        public void SetOwner(FormationSelectionUIController Owner) => this.Owner = Owner;
        
        public void SetButtonText(FormationEnum formation)
        {
            buttonText.text = formation.ToString();
            this.formation = formation;
        }

        public void SetPlayerNumber(PlayerNumber playerNumber) => this.playerNumber = playerNumber;

        public PlayerNumber GetPlayerNumber() => playerNumber;

        private void OnFormationButtonClicked()
        {
            Owner.OnFormationSelected(playerNumber, formation);
        }
    }
}