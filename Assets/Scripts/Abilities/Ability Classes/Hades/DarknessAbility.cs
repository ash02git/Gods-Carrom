﻿using GodsCarrom.Player;
using UnityEngine;

namespace GodsCarrom.Abilites
{
    public class DarknessAbility : Ability //maybe make this premove ability
    {
        private AbilitiesEnum abilityName;

        public DarknessAbility(PlayerNumber playerNumber, AbilitiesEnum abilityName)
        {
            this.playerNumber = playerNumber;
            castTime = AbilityCastTime.PostMove;
            revertTime = AbilityCastTime.PostMove;
            this.abilityName = abilityName;
        }

        public override void OnAbilityCast()
        {
            Debug.Log(abilityName.ToString() + " is cast");
        }

        public override void OnAbilityReverted()
        {
            Debug.Log(abilityName.ToString() + " is reverted");
        }
    }
}