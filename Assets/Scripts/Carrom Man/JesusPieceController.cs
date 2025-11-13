using GodsCarrom.Abilites;
using GodsCarrom.Player;
using System.Collections.Generic;
using UnityEngine;

namespace GodsCarrom.CarromMan
{
    public class JesusPieceController : CarromManController
    {
        Dictionary<AbilitiesEnum, bool> abilityStatus = new Dictionary<AbilitiesEnum, bool>();

        public JesusPieceController(PlayerController owner, CarromManScriptableObject carromSO, CarromManView view) : base(owner, carromSO, view)
        {
            Debug.Log("Jesus piece controller is created");
            abilityStatus.Add(AbilitiesEnum.WaterToWine, false);
        }

        public JesusPieceController(PlayerController owner, CarromManModel carromManModel, CarromManView view) : base(owner, carromManModel, view)
        {
            Debug.Log("Jesus piece controller is created");
            abilityStatus.Add(AbilitiesEnum.WaterToWine, false);
        }

        public override void ActivateAbility(AbilitiesEnum ability)
        {
            Debug.Log(ability.ToString() + " is activated for striking controller");
            abilityStatus[ability] = true;
        }

        public override void DeactivateAbility(AbilitiesEnum ability)
        {
            abilityStatus[ability] = false;
        }

        public override void ProcessCollission(GameObject collidedObject)
        {
            base.ProcessCollission(collidedObject);

            if (abilityStatus[AbilitiesEnum.WaterToWine] == true)
            {
                Debug.Log("Water to wine collission is happening");

                CarromManController collidedController = null;
                //CarromManController collidedController = collidedObject.GetComponent<CarromManView>().GetController();
                if (collidedObject.GetComponent<CarromManView>() != null)
                    collidedController = collidedObject.GetComponent<CarromManView>().GetController();

                if(collidedController != null)
                {
                    //remove from its list
                    collidedController.GetOwnerController().RemovePiece(collidedController);

                    //change owner of controller
                    collidedController.SetOwner(this.GetOwnerController());

                    //add this controller to this player's carrom list
                    GetOwnerController().AddPiece(collidedController);

                    //remove this controller from its player's carrom list
                    //change the appearance - done inside player controller
                }

            }
        }
    }
}