using GodsCarrom.CarromMan;
using GodsCarrom.Main;
using UnityEngine;

namespace GodsCarrom.Hole
{
    public class HoleView : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {   
            CarromManController carromManController = collision.GetComponent<CarromManView>().GetController();
            if (carromManController != null)
            {
                carromManController.DestoryCarromMan();

                GameService.Instance.EventService.OnCarromPotted.InvokeEvent(carromManController);

                GameService.Instance.EventService.OnPointScored.InvokeEvent();
            }
        }
    }
}