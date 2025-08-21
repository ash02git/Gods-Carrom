
using GodsCarrom.CarromMan;
using GodsCarrom.Gods;

namespace GodsCarrom.Events
{
    public class EventService
    {
        public EventController OnPointScored { get; private set; }
        public EventController<CarromManController> OnCarromPotted { get; private set; }

        public EventController<GodScriptableObject, GodScriptableObject> OnGameStarted { get; private set; }

        public EventService()
        {
            OnPointScored = new EventController();
            OnCarromPotted = new EventController<CarromManController>();
            OnGameStarted = new EventController<GodScriptableObject, GodScriptableObject>();
        }
    }
}