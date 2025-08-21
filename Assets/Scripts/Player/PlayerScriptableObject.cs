using GodsCarrom.CarromMan;
using System.Collections.Generic;
using UnityEngine;

namespace GodsCarrom.Player
{
    [CreateAssetMenu( fileName = "NewPlayerScriptableObject", menuName = "ScriptableObjects/PlayerScriptableObject")]
    public class PlayerScriptableObject : ScriptableObject
    {
        public PlayerNumber playerNumber;

        public Sprite carromManSprite;//maybe not needed
        public CarromManScriptableObject carromManDetails;

        public List<Vector2> carromManPositions;
    }
}