using GodsCarrom.Player;
using UnityEngine;

namespace GodsCarrom.Abilites
{
    public class Ability : IAbility
    {
        public PlayerNumber playerNumber;
        public AbilityType abilityType;
        public AbilityCastTime castTime;
        public AbilityCastTime revertTime;

        public virtual void OnAbilityCast() => Debug.Log("Ability has been cast");

        public virtual void PostAbilityCast() { }

        public virtual void OnAbilityReverted() => Debug.Log("Ability has been reverted");
    }
}