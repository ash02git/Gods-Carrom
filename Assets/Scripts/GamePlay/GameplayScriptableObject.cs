using GodsCarrom.CarromMan;
using GodsCarrom.Formations;
using GodsCarrom.Gods;
using GodsCarrom.Hole;
using UnityEngine;

namespace GodsCarrom.Gameplay
{
    [CreateAssetMenu( fileName = "NewGameplayScriptablObject", menuName = "ScriptableObjects/GameplayScriptableObject")]
    public class GameplayScriptableObject : ScriptableObject
    {
        public HoleData holeData;

        public CarromManScriptableObject carromSO;

        public FormationScriptableObject p1FormationSO;
        public FormationScriptableObject p2FormationSO;

        public GodScriptableObject p1GodSO;
        public GodScriptableObject p2GodSO;
    }
}