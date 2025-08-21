using GodsCarrom.Gods;
using GodsCarrom.Player;
using System;

namespace GodsCarrom.UI
{
    public class PlayerUIController
    {
        private PlayerUIView playerUIView;
        private PlayerNumber playerNumber;

        public PlayerUIController(PlayerUIView playerUIView)
        {
            this.playerUIView = playerUIView;

            this.playerUIView.SetController(this);
        }

        public void SetView(GodScriptableObject godSO)
        {
            playerUIView.SetUIView(godSO);
        }
    }
}