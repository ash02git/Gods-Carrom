using GodsCarrom.Main;
using GodsCarrom.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace GodsCarrom.Abilites
{
    public struct AbilityPackage
    {
        public AbilityDetails selectedAbility;
        public Ability abilityClass;
    }

    public struct AbilityNameAndClass
    {
        public AbilitiesEnum abilityName;
        public Ability abilityClass;

        public AbilityNameAndClass(AbilitiesEnum name, Ability aClass)
        {
            abilityName = name; abilityClass = aClass;
        }
    }

    public class AbilityService
    {
        private AbilityDetails selectedAbility;
        private Ability abilityClass;

        private List<AbilityPackage> toBeCasted;
        private List<AbilityPackage> toBeReverted;

        //private List<int> randoms;

        public AbilityService()
        {
            toBeCasted = new List<AbilityPackage>();
            toBeReverted = new List<AbilityPackage>();

            //randoms = new List<int>();
        }

        public void SetAbility(AbilityDetails selectedAbility)
        {
            AbilityPackage package = new AbilityPackage();
            package.selectedAbility = selectedAbility;
            package.abilityClass = UtilityClass.GetAbilityClass(selectedAbility);

            toBeCasted.Add(package);

            //GameService.Instance.gameManager.phaseOver = true;//ability is processed and stored in to be casted
            GameService.Instance.GameplayService.phaseOver = true;//ability is processed and stored in to be casted
        }

        public void PerformAbilityUpdates(AbilityCastTime castTime)
        {
            CheckAndRevertAbilityNew(castTime);
            CheckAndCastAbilityNew(castTime);

            //wait for ability cast time and animations then do phaseOver = true;

            //GameService.Instance.gameManager.phaseOver = true;
            GameService.Instance.GameplayService.phaseOver = true;
        }

        public void CheckAndCastAbilityNew(AbilityCastTime castTime)
        {
            if(toBeCasted.Count > 0)
            {
                List<AbilityPackage> toBeRemoved = new List<AbilityPackage>();

                foreach(AbilityPackage a in toBeCasted)
                {
                    if (a.selectedAbility.castTime == castTime)
                    {
                        a.abilityClass.OnAbilityCast();

                        //move this abilty to toBeReverted list and remove from toBeCasted
                        //if(castTime != AbilityCastTime.PreMove)
                        //    toBeReverted.Add(a);

                        if (a.abilityClass.revertTime != AbilityCastTime.None)
                            toBeReverted.Add(a);

                        //toBeCasted.Remove(a);
                        toBeRemoved.Add(a);
                    }
                }

                foreach(AbilityPackage a in toBeRemoved)
                    toBeCasted.Remove(a);
            }

        }

        public void CheckAndRevertAbilityNew(AbilityCastTime revertTime)
        {
            List<AbilityPackage> toBeRemoved = new List<AbilityPackage>();

            if (toBeReverted.Count > 0)
            {
                foreach(AbilityPackage ability in toBeReverted)
                {
                    if(ability.selectedAbility.revertTime == revertTime)
                    {
                        ability.abilityClass.OnAbilityReverted();

                        //toBeReverted.Remove(ability);
                        toBeRemoved.Add(ability);
                    }
                }
            }

            foreach (AbilityPackage a in toBeRemoved)
                toBeReverted.Remove(a);
        }

        private void CheckAndCastAbility()
        {
            if(selectedAbility.castTime == AbilityCastTime.PreMove)
            {
                abilityClass.OnAbilityCast();
                //apply the ability - means, set phase to PreMove
                //Remove board blocker
                //play the move 
            }
            else if(selectedAbility.castTime == AbilityCastTime.InMove)
            {
                //remove boardblocker
                //just before the move, apply the ability to the CarromMan
            }
            else //means it is post Move
            {
                //remove the board blocker
                //play move
                //set phase to PostMove for ability to take place
            }
        }

        public void ApplyAbility()
        {
            switch(selectedAbility.abilityName)
            {
                case AbilitiesEnum.LoveAll:
                    break;
                case AbilitiesEnum.Resurrect:
                    break;
                case AbilitiesEnum.WaterToWine:
                    break;
            }
        }
    }

    
}