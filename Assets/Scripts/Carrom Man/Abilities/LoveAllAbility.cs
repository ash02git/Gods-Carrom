using GodsCarrom.CarromMan;
using GodsCarrom.Player;

namespace GodsCarrom.Abilites
{
    public class LoveAllAbility : Ability
    {
        private CarromManView carromMan;

        public LoveAllAbility(PlayerNumber playerNumber)
        {
            this.playerNumber = playerNumber;
            abilityType = AbilityType.AffectingIndividualPiece;
            castTime = AbilityCastTime.PostMove;
        }

        public void SetLayer(CarromManController carrom)
        {
            carrom.SetLayer("OnlyBoard");
        }

        public void RevertLayer(CarromManController carrom)
        {
            carrom.SetLayer("Default");
        }

        public override void OnAbilityCast()
        {
            
        }
    }
}