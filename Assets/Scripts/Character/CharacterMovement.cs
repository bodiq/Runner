using System;
using Managers;
using ScriptableObjects;
using StateMachine;
using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterMain characterMain;
        [SerializeField] private CharacterSettings characterSettings;
        [SerializeField] private Rigidbody characterRigidbody;
        [SerializeField] private Animator animator;

        private float _targetHorizontalPosition;
        private float _horizontalInput = 0f;
        private float _verticalInput = 0f;
        
        
        private bool _isRunning;
        
        private Vector3 _targetPosition;
        
        private StateMachine.StateMachine _stateMachine;

        private void Awake()
        {
            SetStateMachineSettings();
        }

        private void Start()
        {
            if (characterRigidbody == null)
            {
                characterRigidbody = GetComponent<Rigidbody>();
            }
        }
        
        private void At(IState from, IState to, IPredicate condition) => _stateMachine.AddTransition(from, to, condition);
        private void Any(IState to, IPredicate condition) => _stateMachine.AddAnyTransition(to, condition);

        private void Update()
        {
            HandleInput();
            
            _stateMachine.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }

        private void SetStateMachineSettings()
        {
            _stateMachine = new StateMachine.StateMachine();
            
            //Declare States
            var idleState = new IdleState(this, animator);
            var runState = new RunState(this, animator);
            
            //DefineTransitions 
            At(idleState, runState, new FuncPredicate(() => _isRunning));
            At(runState, idleState, new FuncPredicate(() => !_isRunning));
            
            //Set initial State
            _stateMachine.SetState(idleState);
        }

        public void MoveCharacter()
        {
            _targetPosition = new Vector3(_targetHorizontalPosition, transform.position.y, transform.position.z + characterSettings.ForwardSpeed * Time.fixedDeltaTime);
            characterRigidbody.MovePosition(Vector3.Lerp(characterRigidbody.position, _targetPosition, characterSettings.SmoothSpeed * Time.fixedDeltaTime));
        }

        private void HandleInput()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");

            if (!_isRunning && Mathf.Abs(_verticalInput) > 0)
            {
                UIManager.Instance.HUDScreen.TurnTip(false);
                _isRunning = true;
            }
            
            if (Mathf.Abs(_horizontalInput) > 0.1f)
            {
                _targetHorizontalPosition += _horizontalInput * characterSettings.SideSpeed * Time.deltaTime;
                _targetHorizontalPosition = Mathf.Clamp(_targetHorizontalPosition, -characterSettings.HorizontalLimit, characterSettings.HorizontalLimit);
            }
        }
        

        public void StopMoving()
        {
            _isRunning = false;
            _targetHorizontalPosition = 0f;
        }
    }
}
