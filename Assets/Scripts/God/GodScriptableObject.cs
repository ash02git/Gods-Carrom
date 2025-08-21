using UnityEngine;

namespace GodsCarrom.Gods
{
    [CreateAssetMenu( fileName = "NewGodScriptableObject", menuName = "ScriptableObjects/GodScriptableObject")]
    public class GodScriptableObject : ScriptableObject
    {
        public GodName godName;
        public Sprite image;
        public Vector2 imageDimensions;

        //dimensions for width and height to display it
        //3 abilities
        //maybe shot power/speed
        //maybe piece weight 
    }
}