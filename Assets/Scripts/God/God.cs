using GodsCarrom.Abilites;
using GodsCarrom.Player;
using System;
using System.Collections.Generic;

namespace GodsCarrom.Gods
{
    public class God
    {
        private PlayerController Owner;
        
        public GodName godName;
        public Dictionary<AbilitiesEnum, bool> abilityStatus = new Dictionary<AbilitiesEnum, bool>();
        public List<Ability> abilitiesList = new List<Ability>();

        public Dictionary<AbilityNameAndClass, bool> abilityStatuso = new Dictionary<AbilityNameAndClass, bool>();

        public PlayerController GetOwner() => Owner;
        public void SetOwner(PlayerController Owner) => this.Owner = Owner;

        public void ActivateAbility(AbilitiesEnum ability) => abilityStatus[ability] = true;

        public void DeactivateAbility(AbilitiesEnum ability) => abilityStatus[ability] = false;

        public void GetAbilityClassAndName(AbilitiesEnum abilityName)
        {
            //return abilityStatuso[abilityName];
        }
    }
}