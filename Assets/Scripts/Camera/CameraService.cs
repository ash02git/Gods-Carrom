using UnityEngine;

namespace GodsCarrom.GameCamera
{
    public class CameraService : MonoBehaviour
    {
        [SerializeField] private Animator animator;


        public void PlayDistortAnim()
        {
            animator.Play("distortAnim");
        }

        public void RevertDistortAnim()
        {
            animator.Play("distortRevertAnim");
        }
    }
}