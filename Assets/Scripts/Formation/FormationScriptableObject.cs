using System.Collections.Generic;
using UnityEngine;

namespace GodsCarrom.Formations
{
    [CreateAssetMenu(fileName = "NewFormationScriptableObject", menuName = "ScriptableObjects/FormationScriptableObject")]
    public class FormationScriptableObject : ScriptableObject
    {
        public FormationEnum formation;
        public List<Vector2> positions;
    }
}