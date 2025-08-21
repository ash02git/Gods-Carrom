using GodsCarrom.Player;

namespace GodsCarrom.Abilites
{
    public class Ability : IAbility
    {
        public PlayerNumber playerNumber;
        public AbilityType abilityType;
        public AbilityCastTime castTime;

        public virtual void OnAbilityCast() { }

        public virtual void PostAbilityCast() { }
    }
}