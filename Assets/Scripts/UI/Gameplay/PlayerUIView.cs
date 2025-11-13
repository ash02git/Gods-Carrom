using GodsCarrom.Gods;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsCarrom.UI
{
    public class PlayerUIView : MonoBehaviour
    {
        private PlayerUIController controller;

        [SerializeField] private TextMeshProUGUI playerNumberGodNameText;
        [SerializeField] private Image godImage;
        [SerializeField] private TextMeshProUGUI carromMenCountText;
        [SerializeField] private Transform abilitiesParent;
        [SerializeField] private UseAbilityUIView useAbilityUI;
        [SerializeField] private GameObject abilityBlocker;

        public void SetController(PlayerUIController controller) => this.controller = controller;

        public void SetUIView(GodScriptableObject godSO)
        {
            playerNumberGodNameText.text = godSO.godName.ToString();
            godImage.sprite = godSO.image;
            carromMenCountText.text = "Carrom Men :- 9";
        }

        public Transform GetAbilitiesParent() => abilitiesParent;

        public void TurnOnAbilityTimerUI() //=> useAbilityUI.gameObject.SetActive(true);
        {
            useAbilityUI.gameObject.SetActive(true);
            //Debug.Log(controller.pl);
        }

        public void TurnOnAbilityBlocker() => abilityBlocker.SetActive(true);

        public void TurnOffAbilityBlocker() => abilityBlocker.SetActive(false);

        public void OnAbilitySelected() => useAbilityUI.OnAbilitySelected();
    }
}