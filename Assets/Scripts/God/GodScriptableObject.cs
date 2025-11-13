using GodsCarrom.Abilites;
using UnityEngine;
using System.Collections.Generic;

namespace GodsCarrom.Gods
{
    [CreateAssetMenu( fileName = "NewGodScriptableObject", menuName = "ScriptableObjects/GodScriptableObject")]
    public class GodScriptableObject : ScriptableObject
    {
        public GodName godName;
        public Sprite image;
        public Vector2 imageDimensions;
        public Sprite godSymbol;

        public List<AbilityDetails> abilities;

        //dimensions for width and height to display it
        //3 abilities
        //maybe shot power/speed
        //maybe piece weight 
    } 
}

/*
 * PlayerService Has:- 1. Player1Controller, 2. Player2Controller
 * 
 * PlayerController Has:- 1. Reference to all CarromMenControllers, 2. A God Object to store the abilities, 3. Reference to strikingCarrom
 * 
 */