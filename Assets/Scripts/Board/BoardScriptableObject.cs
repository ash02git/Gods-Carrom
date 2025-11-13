using GodsCarrom.Hole;
using UnityEngine;

namespace GodsCarrom.Board
{
    [CreateAssetMenu(fileName = "NewBoardScriptableObject", menuName = "ScriptableObjects/BoardScriptableObject")]
    public class BoardScriptableObject : ScriptableObject
    {
        public GameObject boardPrefab;
        public HoleData holeData;
    }
}