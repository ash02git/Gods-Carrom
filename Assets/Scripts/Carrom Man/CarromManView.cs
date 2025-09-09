using GodsCarrom.Main;
using GodsCarrom.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace GodsCarrom.CarromMan
{
    public class CarromManView : MonoBehaviour
    {
        //MVC reference
        private CarromManController controller;

        public Slider aimSlider;
        [SerializeField] private Rigidbody2D rigidbody_2d;
        [SerializeField] private GameObject direction_arrow;

        private void Start()
        {
            rigidbody_2d = GetComponent<Rigidbody2D>();
        }

        public void SetController(CarromManController controller) => this.controller = controller;

        public void SetSpriteColor(Color color) => gameObject.GetComponent<SpriteRenderer>().color = color;

        private void OnMouseDown()
        {
            //if (GameService.Instance.GameplayService.GetTurn() == controller.GetOwner())
            if (GameService.Instance.gameManager.GetTurn() == controller.GetOwner())
                    direction_arrow.SetActive(true);
        }

        private void OnMouseDrag()
        {
            //if (GameService.Instance.GameplayService.GetTurn() == controller.GetOwner())
            if(GameService.Instance.gameManager.GetTurn() == controller.GetOwner())
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = mousePosition - transform.position;

                UpdateDirectionArrowRotation(direction);
                UpdateAimSliderValue(mousePosition, transform.position);
            }
        }

        private void UpdateAimSliderValue(Vector3 mousePosition, Vector3 position)
        {
            aimSlider.value =  controller.CalculateLaunchValue(mousePosition, position);
        }

        private void UpdateDirectionArrowRotation( Vector2 direction)
        {
            float angle = controller.CalculateArrowAngle(direction);
            direction_arrow.transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        private void OnMouseUp()
        {
            //if (GameService.Instance.GameplayService.GetTurn() == controller.GetOwner())
            if (GameService.Instance.gameManager.GetTurn() == controller.GetOwner())
            {
                direction_arrow.SetActive(false);

                SetVelocity();

                //GameService.Instance.GameplayService.SetTurn(PlayerNumber.None);
                //GameService.Instance.GameplayService.ChangeTurn();
                //GameService.Instance.GameplayService.StartTimer();

                //GameService.Instance.gameManager.SetNewPhase(GameplayPhase.InMovePhase);

                GameService.Instance.gameManager.phaseOver = true;
                //GameService.Instance.gameManager.StartMoveTimer();
            }
        }

        private void SetVelocity()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 forceDirection = transform.position - mousePosition;

            rigidbody_2d.velocity = forceDirection.normalized * aimSlider.value;
        }

        public CarromManController GetController() => controller;
    }
}
