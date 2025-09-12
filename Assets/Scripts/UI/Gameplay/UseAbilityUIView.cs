using GodsCarrom.Main;
using GodsCarrom.Gameplay;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GodsCarrom.UI
{
    public class UseAbilityUIView : MonoBehaviour
    {
        [SerializeField] private float time = 8.0f;
        [SerializeField] private Button cancelButton;

        private Coroutine coroutine;

        private void Start()
        {
            cancelButton.onClick.AddListener(OnCancelClicked);
            GameService.Instance.EventService.OnAbilitySelected.AddListener(OnCancelClicked);
        }

        private void OnDestroy()
        {
            cancelButton.onClick.RemoveListener(OnCancelClicked);
            GameService.Instance.EventService.OnAbilitySelected.RemoveListener(OnCancelClicked);
        }

        private void OnCancelClicked()
        {
            //Debug.Log("Ability was not selected");
            StopCoroutine(coroutine);
            gameObject.SetActive(false);

            GameService.Instance.gameManager.phaseOver = true;//inidicating that phase is over

            //GameService.Instance.gameManager.SetNewPhase(GameplayPhase.PlayerPhase);
            //GameService.Instance.gameManager.SetNewPhase(GameplayPhase.PreMovePhase);//new pathing
        }

        public void OnAbilitySelected()
        {
            //Debug.Log("Ability was selected");
            StopCoroutine(coroutine);
            gameObject.SetActive(false);

            //GameService.Instance.gameManager.phaseOver = true;//inidicating that phase is over
        }

        //maybe not needed
        //private void OnAbilitySelected()
        //{
        //    StopCoroutine(coroutine);
        //    gameObject.SetActive(false);
        //}

        private void OnEnable()
        {
            coroutine = StartCoroutine(UseAbilityTimer());
        }

        private IEnumerator UseAbilityTimer()
        {
            //Debug.Log("Ability Selection Started");
            yield return new WaitForSeconds(time);

            OnCancelClicked();
        }
    }
}