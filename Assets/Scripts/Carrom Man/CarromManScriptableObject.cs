using UnityEngine;
using GodsCarrom.Player;

namespace GodsCarrom.CarromMan
{
    [CreateAssetMenu( fileName = "NewCarromManScriptableObject", menuName = "ScriptableObjects/CarromManScriptableObject" )]
    public class CarromManScriptableObject : ScriptableObject
    {
        private PlayerNumber owner;
        //public Sprite sprite;

        public CarromManView carromPrefab;
        public float minLaunchValue;
        public float maxLaunchValue;

        public float minRange;
        public float maxRange;

        public PlayerNumber GetOwner() => owner;

        public void SetOwner(PlayerNumber owner) => this.owner = owner;

        public void CopyFrom(CarromManScriptableObject carromSO)
        {
            //this.sprite = carromSO.sprite;
            this.owner = carromSO.owner;

            this.minLaunchValue = carromSO.minLaunchValue;
            this.maxLaunchValue = carromSO.maxLaunchValue;
            this.minRange = carromSO.minRange;
            this.maxRange = carromSO.maxRange;
        }
    }
}