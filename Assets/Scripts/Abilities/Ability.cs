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

        public PlayerNumber player_number;
        public AbilityType ability_type;
        public AbilityCastTime cast_time;
        public AbilityCastTime revert_time;

        public virtual void OnAbilityCast() => Debug.Log("Ability has been cast");

        public virtual void OnAbilityReverted() => Debug.Log("Ability has been reverted");
    }
}