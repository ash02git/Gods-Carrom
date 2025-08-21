using GodsCarrom.Player;

namespace GodsCarrom.Abilites
{
    public class Ability : IAbility
    {
        public AbilityType abilityType;
        public PlayerNumber playerNumber;

        public virtual void OnAbilityCast() { }

        public virtual void PostAbilityCast() { }
    }
}