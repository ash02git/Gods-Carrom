using GodsCarrom.Main;
using GodsCarrom.Player;

namespace GodsCarrom.Abilites
{
    public class ResurrectAbility : Ability
    {
        public int maxResurrectCount = 2; //can be changed

        public ResurrectAbility(PlayerNumber playerNumber)
        {
            abilityType = AbilityType.AffectingPieceCount;
            this.playerNumber = playerNumber;
        }

        public override void OnAbilityCast()
        {
            int currentPiecesCount = GameService.Instance.CarromMenService.GetPiecesCount(playerNumber);

            int numOfPiecesToBeResurrected = 0;

            if (currentPiecesCount + maxResurrectCount > 9)
                numOfPiecesToBeResurrected = 9 - currentPiecesCount;
            else
                numOfPiecesToBeResurrected = maxResurrectCount;

            GameService.Instance.CarromMenService.CreateCarromMen(playerNumber, numOfPiecesToBeResurrected);
        }
    }
}