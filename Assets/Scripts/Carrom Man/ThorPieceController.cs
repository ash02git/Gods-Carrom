using GodsCarrom.Abilites;
using GodsCarrom.Player;
using System.Collections.Generic;
using UnityEngine;

namespace GodsCarrom.CarromMan
{
    public class ThorPieceController : CarromManController
    {
        Dictionary<AbilitiesEnum, bool> abilityStatus = new Dictionary<AbilitiesEnum, bool>();

        public ThorPieceController(PlayerController owner, CarromManScriptableObject carromSO, CarromManView view) : base(owner, carromSO, view)
        {
            abilityStatus.Add(AbilitiesEnum.ThunderSmash, false);
            abilityStatus.Add(AbilitiesEnum.PowerShot, false);
        }

        public ThorPieceController(PlayerController owner, CarromManModel carromManModel, CarromManView view) : base(owner, carromManModel, view)
        {
            abilityStatus.Add(AbilitiesEnum.ThunderSmash, false);
            abilityStatus.Add(AbilitiesEnum.PowerShot, false);
            abilityStatus.Add(AbilitiesEnum.SuperStrength, false);
        }

        public override void ActivateAbility(AbilitiesEnum ability)
        {
            abilityStatus[ability] = true;
        }

        public override void DeactivateAbility(AbilitiesEnum ability)
        {
            abilityStatus[ability] = false;

            if (ability == AbilitiesEnum.SuperStrength)
                base.SetMass(1.0f);
        }

        public override void SetVelocity(Vector3 vector3, Vector3 position, float aimValue)
        {
            Debug.Log("Inside thor piece controller");
            if (abilityStatus[AbilitiesEnum.PowerShot] == true)
            {
                Debug.Log("Power shot is done");
                base.SetVelocity(vector3, position, aimValue * 2.0f);
            }
            else
            {
                Debug.Log("Normal shot is done");
                base.SetVelocity(vector3, position, aimValue);
            }
        }

        public override void SetVelocity(Vector2 velocity)
        {
            if (abilityStatus[AbilitiesEnum.SuperStrength] == true)
            {
                base.SetMass(2.0f);
            }

            Debug.Log("Inside thor piece controller");
            if (abilityStatus[AbilitiesEnum.PowerShot] == true)
            {
                Debug.Log("Power shot is done");
                base.SetVelocity(velocity * 2.0f);
            }
            else
            {
                Debug.Log("Normal shot is done");
                base.SetVelocity(velocity);
            }
        }

        public override void ProcessCollission(GameObject collidedObject)
        {
            base.ProcessCollission(collidedObject);

            if (abilityStatus[AbilitiesEnum.ThunderSmash] == true)
            {
                CarromManController collidedController = null;
                //CarromManController collidedController = collidedObject.GetComponent<CarromManView>().GetController();
                if (collidedObject.GetComponent<CarromManView>() != null)
                    collidedController = collidedObject.GetComponent<CarromManView>().GetController();

                if (collidedController != null)
                {
                    //remove from list 
                    collidedController.GetOwnerController().RemovePiece(collidedController);

                    // destroy the carrom
                    collidedController.DestoryCarromMan();

                    DeactivateAbility(AbilitiesEnum.ThunderSmash);
                }

            }
        }
    }
}