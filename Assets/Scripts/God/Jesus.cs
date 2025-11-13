using GodsCarrom.Player;
using GodsCarrom.Abilites;
using GodsCarrom.CarromMan;

namespace GodsCarrom.Gods
{
    public class Jesus : God
    {
        public Jesus(PlayerController Owner)
        {
            SetOwner(Owner);

            abilityStatus.Add(AbilitiesEnum.Resurrect, false);
            abilityStatus.Add(AbilitiesEnum.WaterToWine, false);
            abilityStatus.Add(AbilitiesEnum.LoveAll, false);

            abilitiesList.Add(new ResurrectAbility(Owner.GetPlayerNumber(), AbilitiesEnum.Resurrect));
            abilitiesList.Add(new LoveAllAbility(Owner.GetPlayerNumber(), AbilitiesEnum.LoveAll));
            abilitiesList.Add(new WaterToWineAbility(Owner.GetPlayerNumber(), AbilitiesEnum.WaterToWine));

            abilityStatuso.Add(new AbilityNameAndClass(AbilitiesEnum.Resurrect, new ResurrectAbility(Owner.GetPlayerNumber(), AbilitiesEnum.Resurrect)), false);
            abilityStatuso.Add(new AbilityNameAndClass(AbilitiesEnum.LoveAll, new LoveAllAbility(Owner.GetPlayerNumber(), AbilitiesEnum.LoveAll)), false);
            abilityStatuso.Add(new AbilityNameAndClass(AbilitiesEnum.WaterToWine, new WaterToWineAbility(Owner.GetPlayerNumber(), AbilitiesEnum.WaterToWine)), false);
        }

        public void ProcessCollision(CarromManController playerCarrom, CarromManController collidedCarrom)
        {
            
            if (abilityStatus[AbilitiesEnum.WaterToWine] == true)
            {
                collidedCarrom.GetOwnerController().RemovePiece(collidedCarrom);

                collidedCarrom.SetOwner(GetOwner());

                GetOwner().AddPiece(collidedCarrom);
            }
        }
    }
}