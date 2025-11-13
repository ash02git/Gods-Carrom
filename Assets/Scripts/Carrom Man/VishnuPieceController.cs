using GodsCarrom.Abilites;
using GodsCarrom.Player;
using System.Collections.Generic;
using UnityEngine;

namespace GodsCarrom.CarromMan
{
    public class VishnuPieceController : CarromManController
    {
        Dictionary<AbilitiesEnum, bool> abilityStatus = new Dictionary<AbilitiesEnum, bool>();

        public VishnuPieceController(PlayerController owner, CarromManScriptableObject carromSO, CarromManView view) : base(owner, carromSO, view)
        {
            abilityStatus.Add(AbilitiesEnum.ChakraSlice, false);
        }

        public VishnuPieceController(PlayerController owner, CarromManModel carromManModel, CarromManView view) : base(owner, carromManModel, view)
        {
            abilityStatus.Add(AbilitiesEnum.ChakraSlice, false);
        }

        public override void ActivateAbility(AbilitiesEnum ability)
        {
            abilityStatus[ability] = true;
        }

        public override void DeactivateAbility(AbilitiesEnum ability)
        {
            abilityStatus[ability] = false;
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
            base.SetVelocity(velocity);
        }

        public override void ProcessCollission(GameObject collidedObject)
        {
            base.ProcessCollission(collidedObject);
        }

        public override void ProcessTrigger(GameObject triggeredObject)
        {
            base.ProcessTrigger(triggeredObject);

            if (abilityStatus[AbilitiesEnum.ChakraSlice] == true)
            {
                if(triggeredObject.GetComponent<CarromManView>() != null) //-> check if trigger is with another piece
                {
                    if(triggeredObject.GetComponent<CarromManView>().GetController().GetOwner() != GetOwner()) //-> check if trigger is with opponent piece
                    {

                    }
                }
            }
        }
    }
} 