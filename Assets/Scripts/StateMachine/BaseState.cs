using Character;
using UnityEngine;
using Zenject;

namespace StateMachine
{
    public abstract class BaseState : IState
    {
        protected readonly Animator Animator;
        protected readonly CharacterMovement CharacterMovement;
        
        protected static readonly int Run = Animator.StringToHash("Run");
        protected static readonly int Idle = Animator.StringToHash("Idle");
        
        protected const float CrossFadeDuration = 0.1f;
        
        protected BaseState(CharacterMovement characterMovement, Animator animator)
        {
            CharacterMovement = characterMovement;
            Animator = animator;
        }
        
        public virtual void OnEnter()
        {
            //noop
        }

        public virtual void Update()
        {
            //noop
        }

        public virtual void FixedUpdate()
        {
            //noop
        }

        public virtual void OnExit()
        {
            Debug.unityLogger.Log(LogType.Log, "Exit State");
        }
    }
}