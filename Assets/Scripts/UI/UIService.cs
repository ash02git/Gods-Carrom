using GodsCarrom.Gods;
using GodsCarrom.Player;
using System;
using TMPro;
using UnityEngine;

namespace GodsCarrom.UI
{
    public class UIService : MonoBehaviour
    {
        [Header("Formation Selection UI")]
        [SerializeField] private FormationSelectionUIView formationSelectionUIView;
        [SerializeField] private FormationButtonView formationButtonPrefab;
        private FormationSelectionUIController formationSelectionUIController;

        [Header("God Selection UI")]
        [SerializeField] private GodSelectionUIView godSelectionUIView;
        [SerializeField] private GodButtonView godButtonPrefab;
        [SerializeField] private TextMeshProUGUI abilityTextPrefab;
        private GodSelectionUIController godSelectionUIController;
        

        [Header("Gameplay UI")]
        [SerializeField] private GameplayUIView gameplayUIView;
        [SerializeField] private AbilityButtonView abilityButtonPrefab;
        private GameplayUIController gameplayUIController;

        private void Start()
        {
            formationSelectionUIController = new FormationSelectionUIController(formationSelectionUIView, formationButtonPrefab);
            godSelectionUIController = new GodSelectionUIController(godSelectionUIView, godButtonPrefab, abilityTextPrefab);
            gameplayUIController = new GameplayUIController(gameplayUIView, abilityButtonPrefab);
        }

        public void ShowFormationSelectionUI()
        {
            formationSelectionUIView.gameObject.SetActive(true);
        }

        public void HideFormationSelectionUI()
        {
            formationSelectionUIView.gameObject.SetActive(false);
        }

        public void ShowGodSelectionUI()
        {
            godSelectionUIView.gameObject.SetActive(true);
        }

        public void HideGodSelectionUI()
        {
            godSelectionUIView.gameObject.SetActive(false);
        }

        public void ShowGameplayUI()//this function should actually be inside Controller of each UI
        {
            gameplayUIView.gameObject.SetActive(true);
            //gameplayUIController.InitializePlayerUIView();
        }

        public void HideGameplayUI()
        {
            gameplayUIView.gameObject.SetActive(false);
        }

        public void CreateGameplayUI(GodScriptableObject p1GodSO, GodScriptableObject p2GodSO)
        {
            gameplayUIController.InitializePlayersUIView(p1GodSO, p2GodSO);
            //gameplayUIView.gameObject.SetActive(true);
        }

        public void TurnOnAbilityBlocker(PlayerNumber currentTurn)
        {
            gameplayUIController.TurnOnAbilityBlocker(currentTurn);
        }

        public void TurnOffAbilityBlocker(PlayerNumber currentTurn)
        {
            gameplayUIController.TurnOffAbilityBlocker(currentTurn);
        }

    }
}