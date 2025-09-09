using GodsCarrom.Abilites;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsCarrom.UI
{
    public class AbilityButtonView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buttonText;
        private PlayerUIController controller;

        private AbilityDetails ability;

        private void Start() => GetComponent<Button>().onClick.AddListener(OnButtonSelected);
        private void OnDestroy() => GetComponent<Button>().onClick.RemoveListener(OnButtonSelected);

        public void SetButton(AbilityDetails ability)
        {
            buttonText.text = ability.abilityName.ToString();
            this.ability = ability;
        }

        public void SetController(PlayerUIController controller) => this.controller = controller;

        private void OnButtonSelected()
        {
            GetComponent<Button>().interactable = false;//ability can only be used once, so
            controller.OnAbilitySelected(ability);
            //controller.OnAbilitySelected();
        }
    }
}