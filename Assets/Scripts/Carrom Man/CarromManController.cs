using GodsCarrom.Abilites;
using GodsCarrom.Player;
using System;
using UnityEngine;

namespace GodsCarrom.CarromMan
{
    public class CarromManController
    {
        //MVC reference
        private CarromManView carromManView;
        private CarromManScriptableObject carromManSO;
        private CarromManModel carromManModel;

        private PlayerController Owner;

        public CarromManController( PlayerController Owner, CarromManScriptableObject carromManSO, CarromManView carromPrefab)
        {
            carromManView = GameObject.Instantiate(carromPrefab);
            this.carromManSO = carromManSO;
            this.Owner = Owner;

            carromManView.SetController(this);
            //SetColor();
        }

        public CarromManController( PlayerController Owner, CarromManModel model, CarromManView prefab)
        {
            carromManModel = model;
            carromManView = GameObject.Instantiate(prefab);
            this.Owner = Owner;
            carromManView.SetController(this);
        }

        public PlayerNumber GetOwner() => Owner.GetPlayerNumber();

        public void SetOwner(PlayerController Owner) => this.Owner = Owner;

        public PlayerController GetOwnerController() => Owner;
        
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
            //float value = Mathf.InverseLerp(carromManSO.minRange, carromManSO.maxRange, distance);
            float value = Mathf.InverseLerp(carromManModel.minRange, carromManModel.maxRange, distance);

            //return Mathf.Lerp(carromManSO.minLaunchValue, carromManSO.maxLaunchValue, value);
            return Mathf.Lerp(carromManModel.minLaunchValue, carromManModel.maxLaunchValue, value);
        }

        public float CalculateArrowAngle(Vector2 direction)
        {
            return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90.0f;
        }

        public void SetPosition()
        {
            
        }

        public void SetLayer(string v)
        {
            carromManView.gameObject.layer = LayerMask.NameToLayer(v);
        }

        public void SetSprite(Sprite godSymbol)
        {
            carromManView.SetSprite(godSymbol);
        }

        public virtual void ProcessCollission(GameObject collidedObject)
        {
            //Debug.Log("Collided");
        }

        public virtual void ProcessTrigger(GameObject triggeredObject)
        {

        }

        public virtual void ActivateAbility(AbilitiesEnum abilityName)
        {
            Debug.Log("Ability is activated for striking controller");
        }

        public virtual void DeactivateAbility(AbilitiesEnum abilityName)
        {
            Debug.Log("Ability is deactivate for striking controller");
        }

        public virtual void SetVelocity(Vector3 mousePos, Vector3 position, float aimValue)
        {
            Debug.Log("Aim value is " + aimValue);
            Vector2 forceDirection = position - mousePos;
            carromManView.SetVelocity(forceDirection.normalized * aimValue);
        }

        public virtual void SetVelocity(Vector2 velocity)
        {
            Debug.Log("THe velocity is " + velocity);
            carromManView.SetVelocity(velocity);
        }

        public void HidePiece()
        {
            carromManView.HidePiece();
        }

        public void ShowPiece()
        {
            carromManView.ShowPiece();
        }

        public void SetScale(float v)
        {
            carromManView.SetScale(v);
        }

        public void SetMass(float mass)
        {
            carromManView.SetMass(mass);
        }
    }
}