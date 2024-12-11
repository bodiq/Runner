using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterMain characterMain;
        [SerializeField] private CharacterSettings characterSettings;
        [SerializeField] private Rigidbody characterRigidbody;

        private float _targetHorizontalPosition;
        private bool _isRunning;
        
        private Vector3 _targetPosition;
        
        private void Start()
        {
            if (characterRigidbody == null)
            {
                characterRigidbody = GetComponent<Rigidbody>();
            }
        }

        private void Update()
        {
            HandleInput();
        }

        private void FixedUpdate()
        {
            if (_isRunning)
            {
                MoveCharacter();
            }
        }

        private void MoveCharacter()
        {
            _targetPosition = new Vector3(_targetHorizontalPosition, transform.position.y, transform.position.z + characterSettings.ForwardSpeed * Time.fixedDeltaTime);
            characterRigidbody.MovePosition(Vector3.Lerp(characterRigidbody.position, _targetPosition, characterSettings.SmoothSpeed * Time.fixedDeltaTime));
        }

        private void HandleInput()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            if (!_isRunning && Mathf.Abs(vertical) > 0)
            {
                _isRunning = true;
                characterMain.CharacterAnimator.SetRunningState();
            }
            
            
            if (Mathf.Abs(horizontal) > 0.1f)
            {
                _targetHorizontalPosition += horizontal * characterSettings.SideSpeed * Time.deltaTime;
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
