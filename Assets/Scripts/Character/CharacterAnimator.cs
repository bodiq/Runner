using System;
using UnityEngine;

namespace Character
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        private static readonly int RunningState = Animator.StringToHash("Run");

        public void SetRunningState()
        {
            animator.SetTrigger(RunningState);
        }

        public void SetAnimationSpeed(float speed)
        {
            animator.speed = speed;
        }
    }
}