using GodsCarrom.Gods;
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
        [SerializeField] private Button Ability1Button;
        [SerializeField] private Button Ability2Button;
        [SerializeField] private Button Ability3Button;

        public void SetController(PlayerUIController controller) => this.controller = controller;

        public void SetUIView(GodScriptableObject godSO)
        {
            playerNumberGodNameText.text = godSO.godName.ToString();
            godImage.sprite = godSO.image;
            carromMenCountText.text = "9";

            Ability1Button.GetComponentInChildren<TextMeshProUGUI>().text = "";
            Ability2Button.GetComponentInChildren<TextMeshProUGUI>().text = "";
            Ability3Button.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
    }
}