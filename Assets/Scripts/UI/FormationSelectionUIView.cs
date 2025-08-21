using GodsCarrom.Formations;
using GodsCarrom.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsCarrom.UI
{
    public class FormationSelectionUIView : MonoBehaviour
    {
        private FormationSelectionUIController controller;
        
        [SerializeField] private Transform p1Container;
        [SerializeField] private Transform p2Container;

        [SerializeField] private TextMeshProUGUI p1SelectedText;
        [SerializeField] private TextMeshProUGUI p2SelectedText;

        [SerializeField] private Button startGameButton;

        private void Start()
        {
            startGameButton.onClick.AddListener(OnStartGameClicked);
        }

        public void SetDefaultText()
        {
            p1SelectedText.text = "Selected : " + FormationEnum.Default.ToString();
            p1SelectedText.text = "Selected : " + FormationEnum.Default.ToString();
        }

        public void SetController(FormationSelectionUIController controller) => this.controller = controller;

        public FormationButtonView AddButtonInP1Container(FormationButtonView prefab)
        {
            return GameObject.Instantiate(prefab, p1Container) as FormationButtonView;
        }

        public FormationButtonView AddButtonInP2Container(FormationButtonView prefab)
        {
            return GameObject.Instantiate(prefab, p2Container) as FormationButtonView;
        }
        

        public void SetSelectedText(PlayerNumber playerNumber, FormationEnum formation)
        {
            if(playerNumber == PlayerNumber.Player1)
                p1SelectedText.text = "Selected : " + formation.ToString();
            else if(playerNumber == PlayerNumber.Player2)
                p2SelectedText.text = "Selected : " + formation.ToString();
        }

        private void OnStartGameClicked() => controller.OnStartGameClicked();
    }
}