using UnityEngine;

namespace Character
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        private static readonly int RunningState = Animator.StringToHash("Run");
        private static readonly int Idle = Animator.StringToHash("Idle");

        public void SetRunningState()
        {
            animator.SetTrigger(RunningState);
        }

        public void SetIdleState()
        {
            animator.SetTrigger(Idle);
        }

        public void SetAnimationSpeed(float speed)
        {
            animator.speed = speed;
        }
    }
}