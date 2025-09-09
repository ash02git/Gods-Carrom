
using GodsCarrom.Abilites;
using GodsCarrom.CarromMan;
using GodsCarrom.Gameplay;
using GodsCarrom.Gods;
using GodsCarrom.Player;

namespace GodsCarrom.Events
{
    public class EventService
    {
        public EventController OnPointScored { get; private set; }
        public EventController<CarromManController> OnCarromPotted { get; private set; }

        public EventController<GodScriptableObject, GodScriptableObject> OnGameStarted { get; private set; }

        /*
         *  I need three events
         *  1. OnTurnStarted - When turn starts, the player is allowed to select an ability if he/she wants
         *  2. OnAbilitySelected - Add the ability to abilityService. Any PreMove ability can be triggered here
         *  2. OnMovePlayed - Once the player has struck the piece. Any InMove ability can be triggered here
         *  3. OnMoveFinished - Once the move is over, means when the pieces have stopped moving. Any PostMove abilities can be triggered here
        */

        public EventController<GameplayPhase> OnPhaseCompleted { get; private set; }
        public EventController OnMoveCompleted { get; private set; }


        public EventController OnAbilitySelected { get; private set; }
        public EventController OnAbilityNotSelected { get; private set; }

        public EventController<PlayerNumber> OnTurnStarted { get; private set; }

        public EventService()
        {
            OnPointScored = new EventController();
            OnCarromPotted = new EventController<CarromManController>();
            OnGameStarted = new EventController<GodScriptableObject, GodScriptableObject>();

            OnPhaseCompleted = new EventController<GameplayPhase>();
            OnMoveCompleted = new EventController();

            OnAbilitySelected = new EventController();

            OnTurnStarted = new EventController<PlayerNumber>();
        }
    }
}