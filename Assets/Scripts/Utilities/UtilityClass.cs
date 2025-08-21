using GodsCarrom.Formations;
using GodsCarrom.Gods;
using UnityEngine;

namespace GodsCarrom.Utilities
{
    public static class UtilityClass
    {
        public static FormationScriptableObject GetFormationSO(FormationEnum formation)
        {
            Debug.Log("Formation passed is " +  formation);

            switch(formation)
            {
                case FormationEnum.DefaultInverse:
                    Debug.Log("Inside DefaultInverse");
                    return Resources.Load<FormationScriptableObject>("ScriptableObjects/FormationSOs/DefaultInverseFormation");
                case FormationEnum.SingleLine:
                    Debug.Log("Inside DefaultInverse");
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
    }
}