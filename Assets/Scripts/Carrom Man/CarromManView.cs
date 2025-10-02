using GodsCarrom.Main;
using GodsCarrom.Gameplay;
using UnityEngine;
using UnityEngine.UI;
using System;

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
            {
                direction_arrow.SetActive(true);
                //controller.GetOwnerController().SetStrikingPiece(controller);//this is new line
            }
        }

        private void OnMouseDrag()
        {
            //if (GameService.Instance.GameplayService.GetTurn() == controller.GetOwner())
            if(GameService.Instance.gameManager.GetTurn() == controller.GetOwner())
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 0; //can be removed maybe
                Vector2 direction = mousePosition - transform.position;

                UpdateDirectionArrowRotation(direction);
                UpdateAimSliderValue(mousePosition, transform.position);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //only for certain abilities this needs to be applicable
            controller.ProcessCollission(collision.gameObject);
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
            GameService.Instance.gameManager.phaseOver = true;//phaseOver is done first so that InMove can happen
            Debug.Log("Set Player Phase as over");
            controller.GetOwnerController().SetStrikingPiece(controller);
            
            //if (GameService.Instance.GameplayService.GetTurn() == controller.GetOwner())
            if (GameService.Instance.gameManager.GetTurn() == controller.GetOwner())
            {
                direction_arrow.SetActive(false);

                

                //controller.SetVelocity(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position, aimSlider.value);
                //controller.GetOwnerController().SetStrikingVelocity(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position, aimSlider.value);
                controller.SetVelocity(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position, aimSlider.value);
                //SetVelocity();

                //GameService.Instance.GameplayService.SetTurn(PlayerNumber.None);
                //GameService.Instance.GameplayService.ChangeTurn();
                //GameService.Instance.GameplayService.StartTimer();

                //GameService.Instance.gameManager.SetNewPhase(GameplayPhase.InMovePhase);

                //GameService.Instance.gameManager.phaseOver = true;


                //GameService.Instance.gameManager.StartMoveTimer();
            }
        }

        public void SetVelocity(Vector2 velocity)
        {
            //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector2 forceDirection = transform.position - mousePosition;

            //rigidbody_2d.velocity = forceDirection.normalized * aimSlider.value;

            rigidbody_2d.velocity = velocity;
        }

        public CarromManController GetController() => controller;

        public void SetSprite(Sprite godSymbol) => GetComponent<SpriteRenderer>().sprite = godSymbol;
    }
}
