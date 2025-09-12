using GodsCarrom.Abilites;
using GodsCarrom.CarromMan;
using GodsCarrom.Formations;
using GodsCarrom.Gods;
using GodsCarrom.Player;
using UnityEngine;

namespace GodsCarrom.Utilities
{
    public static class UtilityClass
    {
        public static PlayerNumber GetOpponent(PlayerNumber playerNumber)
        {
            if (playerNumber == PlayerNumber.Player1)
                return PlayerNumber.Player2;
            else if (playerNumber == PlayerNumber.Player2)
                return PlayerNumber.Player1;
            else
                return PlayerNumber.None;
        }

        public static CarromManController CreateSpecificCarromMan(PlayerController playerController, CarromManScriptableObject carromSO, CarromManView prefab, GodName godName)
        {
            switch(godName)
            {
                case GodName.Jesus:
                    return new JesusPieceController(playerController, carromSO, prefab);

                case GodName.Thor:
                    return new ThorPieceController(playerController, carromSO, prefab);

                default:
                    return new JesusPieceController(playerController, carromSO, prefab);
            }
        }

        public static FormationScriptableObject GetFormationSO(FormationEnum formation)
        {
            switch(formation)
            {
                case FormationEnum.DefaultInverse:
                    return Resources.Load<FormationScriptableObject>("ScriptableObjects/FormationSOs/DefaultInverseFormation");
                case FormationEnum.SingleLine:
                    return Resources.Load<FormationScriptableObject>("ScriptableObjects/FormationSOs/SingleLineFormation");
                case FormationEnum.Rectangle:
                    return Resources.Load<FormationScriptableObject>("ScriptableObjects/FormationSOs/RectangleFormation");
                case FormationEnum.Curved:
                    return Resources.Load<FormationScriptableObject>("ScriptableObjects/FormationSOs/CurvedFormation");
                case FormationEnum.CurvedInverse:
                    return Resources.Load<FormationScriptableObject>("ScriptableObjects/FormationSOs/CurvedInverseFormation");

                default:
                    return Resources.Load<FormationScriptableObject>("ScriptableObjects/FormationSOs/DefaultFormation");
            }
        }

        public static GodScriptableObject GetGodSO(GodName godName)
        {
            switch(godName)
            {
                case GodName.Jesus:
                    return Resources.Load<GodScriptableObject>("ScriptableObjects/GodSOs/God-Jesus");
                case GodName.Thor:
                    return Resources.Load<GodScriptableObject>("ScriptableObjects/GodSOs/God-Thor");
                case GodName.Loki:
                    return Resources.Load<GodScriptableObject>("ScriptableObjects/GodSOs/God-Loki");
                case GodName.Vishnu:
                    return Resources.Load<GodScriptableObject>("ScriptableObjects/GodSOs/God-Vishnu");
                case GodName.Shiva:
                    return Resources.Load<GodScriptableObject>("ScriptableObjects/GodSOs/God-Shiva");
                case GodName.Zeus:
                    return Resources.Load<GodScriptableObject>("ScriptableObjects/GodSOs/God-Zeus");
                case GodName.Hades:
                    return Resources.Load<GodScriptableObject>("ScriptableObjects/GodSOs/God-Hades");

                default://Jesus as default for now
                    return Resources.Load<GodScriptableObject>("ScriptableObjects/GodSOs/God-Jesus");
            }
        }

        public static Ability GetAbilityClass(AbilityDetails ability)
        {
            AbilitiesEnum abilityName = ability.abilityName;
            switch(abilityName)
            {
                case AbilitiesEnum.LoveAll:
                    return new LoveAllAbility(ability.GetPlayerNumber(), abilityName);

                case AbilitiesEnum.Resurrect:
                    return new ResurrectAbility(ability.GetPlayerNumber(), abilityName);

                case AbilitiesEnum.WaterToWine:
                    return new WaterToWineAbility(ability.GetPlayerNumber(), abilityName);

                case AbilitiesEnum.Darkness:
                    return new DarknessAbility(ability.GetPlayerNumber(), abilityName);

                case AbilitiesEnum.Invisibility:
                    return new InvisibilityAbility(ability.GetPlayerNumber(), abilityName);

                case AbilitiesEnum.TradeDeath:
                    return new TradeDeathAbility(ability.GetPlayerNumber(), abilityName);

                case AbilitiesEnum.Disguise:
                    return new DisguiseAbility(ability.GetPlayerNumber(), abilityName);

                case AbilitiesEnum.Trickster:
                    return new TricksterAbility(ability.GetPlayerNumber(), abilityName);

                case AbilitiesEnum.Distort:
                    return new DistortAbility(ability.GetPlayerNumber(), abilityName);

                case AbilitiesEnum.ThirdEye:
                    return new ThirdEyeAbility(ability.GetPlayerNumber(), abilityName);

                case AbilitiesEnum.PowerShot:
                    return new PowerShotAbility(ability.GetPlayerNumber(), abilityName);

                case AbilitiesEnum.SuperStrength:
                    return new SuperStrengthAbility(ability.GetPlayerNumber(), abilityName);

                case AbilitiesEnum.ThunderSmash:
                    return new ThunderSmashAbility(ability.GetPlayerNumber(), abilityName);

                case AbilitiesEnum.ChakraSlice:
                    return new ChakraSliceAbility(ability.GetPlayerNumber(), abilityName);

                case AbilitiesEnum.CreateAndDestory:
                    return new CreateAndDestroyAbility(ability.GetPlayerNumber(), abilityName);

                case AbilitiesEnum.CloudVision:
                    return new CloudVisionAbility(ability.GetPlayerNumber(), abilityName);

                case AbilitiesEnum.SireDemigods:
                    return new SireDemigodsAbility(ability.GetPlayerNumber(), abilityName);

                default:
                    return null;
            }
        }
    }
}