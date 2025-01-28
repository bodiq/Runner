using Character;
using UnityEngine;

namespace StateMachine
{
    public class IdleState : BaseState
    {
        public IdleState(CharacterMovement characterMovement, Animator animator) : base(characterMovement, animator)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("Idle State On Enter");
            Animator.CrossFade(Idle, CrossFadeDuration);
        }

        public override void FixedUpdate()
        {
            //Some Stuff
        }
    }
}