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
        }

        public override void ActivateAbility(AbilitiesEnum ability)
        {
            abilityStatus[ability] = true;
        }

        public override void DeactivateAbility(AbilitiesEnum ability)
        {
            abilityStatus[ability] = false;
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