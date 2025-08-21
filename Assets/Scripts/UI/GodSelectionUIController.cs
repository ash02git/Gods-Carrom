using GodsCarrom.Gods;
using GodsCarrom.Main;
using GodsCarrom.Player;
using GodsCarrom.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GodsCarrom.UI
{
    public class GodSelectionUIController
    {
        private GodSelectionUIView godSelectionUIView;
        private GodButtonView godButtonPrefab;

        private List<GodButtonView> p1GodButtons;
        private List<GodButtonView> p2GodButtons;

        private GodName p1ChosenGod;
        private GodName p2ChosenGod;

        public GodSelectionUIController(GodSelectionUIView godSelectionUIView, GodButtonView godButtonPrefab)
        {
            this.godSelectionUIView = godSelectionUIView;
            this.godButtonPrefab = godButtonPrefab;

            this.godSelectionUIView.SetController(this);

            p1GodButtons = new List<GodButtonView>();
            p2GodButtons = new List<GodButtonView>();

            CreateGodButtons();
            godSelectionUIView.SetDefaultText();
        }

        private void CreateGodButtons()
        {
            foreach(GodName godName in Enum.GetValues(typeof(GodName)))
            {
                GodScriptableObject godSO = UtilityClass.GetGodSO(godName);

                GodButtonView newGodButton1 = godSelectionUIView.AddButtonInP1Container(godButtonPrefab);
                newGodButton1.SetNameText(godName);
                newGodButton1.SetImage(godSO.image, godSO.imageDimensions);
                newGodButton1.SetPlayerNumber(PlayerNumber.Player1);
                newGodButton1.SetOwner(this);
                p1GodButtons.Add(newGodButton1);

                GodButtonView newGodButton2 = godSelectionUIView.AddButtonInP2Container(godButtonPrefab);
                newGodButton2.SetNameText(godName);
                newGodButton2.SetImage(godSO.image, godSO.imageDimensions);
                newGodButton2.SetPlayerNumber(PlayerNumber.Player2);
                newGodButton2.SetOwner(this);
                p2GodButtons.Add(newGodButton2);

                //later add ability texts as well
            }
        }

        public void OnGodSelected(PlayerNumber playerNumber, GodName godName)
        {
            godSelectionUIView.SetSelectedText(playerNumber, godName);

            if (playerNumber == PlayerNumber.Player1)
                p1ChosenGod = godName;

            if (playerNumber == PlayerNumber.Player2)
                p2ChosenGod = godName;
        }
        
        public void OnNextClicked()
        {
            GameService.Instance.GameplayService.SetGodSOs(p1ChosenGod, p2ChosenGod);
            GameService.Instance.UIService.ShowFormationSelectionUI();
        }

    }

}