using GodsCarrom.Gods;
using System;
using UnityEngine;

namespace GodsCarrom.UI
{
    public class UIService : MonoBehaviour
    {
        [Header("Formation Selection UI")]
        private FormationSelectionUIController formationSelectionUIController;
        [SerializeField] private FormationSelectionUIView formationSelectionUIView;
        [SerializeField] private FormationButtonView formationButtonPrefab;

        [Header("God Selection UI")]
        private GodSelectionUIController godSelectionUIController;
        [SerializeField] private GodSelectionUIView godSelectionUIView;
        [SerializeField] private GodButtonView godButtonPrefab;

        [Header("Gameplay UI")]
        private GameplayUIController gameplayUIController;
        [SerializeField] private GameplayUIView gameplayUIView;

        private void Start()
        {
            formationSelectionUIController = new FormationSelectionUIController(formationSelectionUIView, formationButtonPrefab);
            godSelectionUIController = new GodSelectionUIController(godSelectionUIView, godButtonPrefab);
            gameplayUIController = new GameplayUIController(gameplayUIView);
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
            gameplayUIController.InitializePlayersUI(p1GodSO, p2GodSO);
        }
    }
}