using Character;
using UnityEngine;

namespace StateMachine
{
    public class RunState : BaseState
    {
        public RunState(CharacterMovement characterMovement, Animator animator) : base(characterMovement, animator)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("Run State On Enter");
            Animator.CrossFade(Run, CrossFadeDuration);
        }
        
        public override void FixedUpdate()
        {
            CharacterMovement.MoveCharacter();
        }
    }
}