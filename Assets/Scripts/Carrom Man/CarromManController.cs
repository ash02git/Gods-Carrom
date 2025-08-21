using GodsCarrom.Player;
using UnityEngine;

namespace GodsCarrom.CarromMan
{
    public class CarromManController
    {
        //MVC references
        private CarromManView carromManView;
        private CarromManScriptableObject carromManSO;

        private PlayerController Owner;

        public CarromManController( PlayerController Owner, CarromManScriptableObject carromManSO, CarromManView carromManPrefab)
        {
            carromManView = GameObject.Instantiate(carromManPrefab);
            this.carromManSO = carromManSO;
            this.Owner = Owner;

            carromManView.SetController(this);
            SetColor();
        }

        public PlayerNumber GetOwner() => Owner.GetPlayerNumber();
        
        public void SetPosition(Vector2 position) => carromManView.transform.position = position;

        public void SetColor()
        {
            if (Owner.GetPlayerNumber() == PlayerNumber.Player1)
                carromManView.SetSpriteColor(Color.white);
            else if (Owner.GetPlayerNumber() == PlayerNumber.Player2)
                carromManView.SetSpriteColor(Color.black);
        }

        public void DestoryCarromMan()// => carromManView.HideCarromMan();
        {
            GameObject.Destroy(carromManView.gameObject);
            carromManView = null;

            Owner.DeleteController(this);
        }

        public float CalculateLaunchValue(Vector3 mousePosition, Vector3 position)
        {
            float distance = Mathf.Sqrt(Mathf.Pow(mousePosition.x - position.x, 2) + Mathf.Pow(mousePosition.y - position.y, 2));//better to multiply than us Math.Power of 2
            float value = Mathf.InverseLerp(carromManSO.minRange, carromManSO.maxRange, distance);

            return Mathf.Lerp(carromManSO.minLaunchValue, carromManSO.maxLaunchValue, value);
        }

        public float CalculateArrowAngle(Vector2 direction)
        {
            return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90.0f;
        }
    }
}