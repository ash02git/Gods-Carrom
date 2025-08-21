using GodsCarrom.Gods;
using GodsCarrom.Player;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GodsCarrom.UI
{
    public class GodButtonView : MonoBehaviour
    {
        private PlayerNumber playerNumber;
        private GodName godName;

        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI ability1Text;
        [SerializeField] private TextMeshProUGUI ability2Text;
        [SerializeField] private TextMeshProUGUI ability3Text;

        private GodSelectionUIController Owner;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnGodButtonClicked);
        }

        public void SetOwner(GodSelectionUIController Owner) => this.Owner = Owner;

        public void SetNameText(GodName godName)
        {
            nameText.text = godName.ToString();
            this.godName = godName;
        }

        public void SetImage(Sprite sprite, Vector2 dimensions)
        {
            image.sprite = sprite;
            image.gameObject.GetComponent<RectTransform>().sizeDelta = dimensions;
        }

        public void SetPlayerNumber(PlayerNumber playerNumber) => this.playerNumber = playerNumber;

        public void SetAbilityTexts()
        {

        }

        private void OnGodButtonClicked()
        {
            Owner.OnGodSelected(playerNumber, godName);
        }
    }
}