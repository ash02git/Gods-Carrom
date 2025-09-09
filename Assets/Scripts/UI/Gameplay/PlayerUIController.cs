using GodsCarrom.Abilites;
using GodsCarrom.Gods;
using GodsCarrom.Main;
using GodsCarrom.Player;
using System.Collections.Generic;
using UnityEngine;

namespace GodsCarrom.UI
{
    public class PlayerUIController
    {
        private PlayerUIView playerUIView;
        private PlayerNumber playerNumber;

        private AbilityButtonView abilityButtonPrefab;
        private List<AbilityButtonView> abilityButtons;

        private Transform abilitiesParent;

        public PlayerUIController(PlayerNumber playerNumber, PlayerUIView playerUIView, AbilityButtonView abilityButtonPrefab)
        {
            this.playerNumber = playerNumber;
            this.playerUIView = playerUIView;
            this.abilityButtonPrefab = abilityButtonPrefab;

            this.playerUIView.SetController(this);

            abilityButtons = new List<AbilityButtonView>();

            GameService.Instance.EventService.OnTurnStarted.AddListener(TurnOnAbilitySelectionTimer);
        }

        ~PlayerUIController()
        {
            GameService.Instance.EventService.OnTurnStarted.RemoveListener(TurnOnAbilitySelectionTimer);
        }

        private void TurnOnAbilitySelectionTimer(PlayerNumber player)
        {
            if (playerNumber == player)
                playerUIView.TurnOnAbilityTimerUI();
        }

        public void OnAbilitySelected()
        {
            playerUIView.OnAbilitySelected();
        }

        public void InitializeView(GodScriptableObject godSO)
        {
            playerUIView.SetUIView(godSO);

            CreateAbilityButtons(godSO.abilities);
        }

        private void CreateAbilityButtons(List<AbilityDetails> abilities)
        {
            foreach(AbilityDetails ability in abilities)
            {
                AbilityButtonView newButton = GameObject.Instantiate(abilityButtonPrefab, playerUIView.GetAbilitiesParent());
                newButton.SetButton(ability);
                newButton.SetController(this);

                abilityButtons.Add(newButton);
            }
        }

        public void OnAbilitySelected(AbilityDetails ability)
        {
            Debug.Log(ability.abilityName.ToString()+ " ability is selected");
            playerUIView.OnAbilitySelected();
            ability.SetPlayerNumber(playerNumber);
            GameService.Instance.AbilityService.SetAbility(ability);
        }

        public void TurnOnAbilityBlocker()
        {
            playerUIView.TurnOnAbilityBlocker();
        }

        public void TurnOffAbilityBlocker()
        {
            playerUIView.TurnOffAbilityBlocker();
        }
    }
}