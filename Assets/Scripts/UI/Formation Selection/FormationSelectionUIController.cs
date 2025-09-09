using GodsCarrom.Formations;
using GodsCarrom.Main;
using GodsCarrom.Player;
using System;
using System.Collections.Generic;

namespace GodsCarrom.UI
{
    public class FormationSelectionUIController
    {
        private FormationSelectionUIView formationSelectionUIView;
        private FormationButtonView formationButtonPrefab;

        private List<FormationButtonView> p1FormationButtons;
        private List<FormationButtonView> p2FormationButtons;

        private FormationEnum p1chosenFormation;
        private FormationEnum p2chosenFormation;

        public FormationSelectionUIController(FormationSelectionUIView formationSelectionUIView, FormationButtonView formationButtonPrefab)
        {
            this.formationSelectionUIView = formationSelectionUIView;
            this.formationButtonPrefab = formationButtonPrefab;

            this.formationSelectionUIView.SetController(this);

            p1FormationButtons = new List<FormationButtonView>();
            p2FormationButtons = new List<FormationButtonView>();

            CreateFormationButtons();
            formationSelectionUIView.SetDefaultText();
        }

        public void OnFormationSelected(PlayerNumber playerNumber, FormationEnum formation)
        {
            formationSelectionUIView.SetSelectedText(playerNumber, formation);
            
            if(playerNumber == PlayerNumber.Player1)
                p1chosenFormation = formation;

            if(playerNumber == PlayerNumber.Player2)
                p2chosenFormation = formation;
        }

        private void CreateFormationButtons()
        {
            foreach(FormationEnum formation in Enum.GetValues(typeof(FormationEnum)))
            {
                FormationButtonView newButton1 = formationSelectionUIView.AddButtonInP1Container(formationButtonPrefab);
                newButton1.SetButtonText(formation);
                newButton1.SetPlayerNumber(PlayerNumber.Player1);
                newButton1.SetOwner(this);
                p1FormationButtons.Add(newButton1);

                FormationButtonView newButton2 = formationSelectionUIView.AddButtonInP2Container(formationButtonPrefab);
                newButton2.SetButtonText(formation);
                newButton2.SetPlayerNumber(PlayerNumber.Player2);
                newButton2.SetOwner(this);
                p2FormationButtons.Add(newButton2);
            }
        }

        public void OnStartGameClicked()
        {
            GameService.Instance.GameplayService.SetFormationSOs(p1chosenFormation, p2chosenFormation);
            GameService.Instance.GameplayService.CreateGameplay();
            GameService.Instance.UIService.ShowGameplayUI();
        }
    }
}