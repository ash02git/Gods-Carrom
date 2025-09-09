using GodsCarrom.Formations;
using GodsCarrom.Gods;
using GodsCarrom.Player;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsCarrom.UI
{
    public class GodSelectionUIView : MonoBehaviour
    {
        private GodSelectionUIController controller;

        [SerializeField] private Transform p1Container;
        [SerializeField] private Transform p2Container;

        [SerializeField] private TextMeshProUGUI p1SelectedText;
        [SerializeField] private TextMeshProUGUI p2SelectedText;

        [SerializeField] private Button nextButton;

        private void Start()
        {
            nextButton.onClick.AddListener(OnNextClicked);
        }

        public void SetDefaultText()
        {
            p1SelectedText.text = "Selected : " + GodName.Jesus.ToString();
            p1SelectedText.text = "Selected : " + GodName.Jesus.ToString();
        }

        public void SetController(GodSelectionUIController controller) => this.controller = controller;

        public GodButtonView AddButtonInP1Container(GodButtonView prefab)
        {
            return GameObject.Instantiate(prefab, p1Container) as GodButtonView;
        }

        public GodButtonView AddButtonInP2Container(GodButtonView prefab)
        {
            return GameObject.Instantiate(prefab, p2Container) as GodButtonView;
        }

        public void SetSelectedText(PlayerNumber playerNumber, GodName godName)
        {
            if (playerNumber == PlayerNumber.Player1)
                p1SelectedText.text = "Selected : " + godName.ToString();
            else if (playerNumber == PlayerNumber.Player2)
                p2SelectedText.text = "Selected : " + godName.ToString();
        }

        private void OnNextClicked() => controller.OnNextClicked();
    }
}
