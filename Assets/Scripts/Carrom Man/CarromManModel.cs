using GodsCarrom.Player;
using UnityEngine;

namespace GodsCarrom.CarromMan
{
    public class CarromManModel
    {
        public PlayerNumber owner;
        public Sprite sprite;

        public float minLaunchValue;
        public float maxLaunchValue;

        public float minRange;
        public float maxRange;

        public CarromManModel(CarromManScriptableObject so)
        {
            minLaunchValue = so.minLaunchValue;
            maxLaunchValue = so.maxLaunchValue;
            minRange = so.minRange;
            maxRange = so.maxRange;
        }

        public void SetOwner(PlayerNumber playerNumber) => owner = playerNumber;
        public void SetSprite(Sprite sprite) => this.sprite = sprite;
    }
}