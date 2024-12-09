using ScriptableObjects;
using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterMain characterMain;
        [SerializeField] private CharacterSettings characterSettings;
        [SerializeField] private Rigidbody rigidbody;

        private float _targetHorizontalPosition;
        private bool _isRunning;
        
        private Vector3 _targetPosition;
        
        private void Start()
        {
            if (rigidbody == null)
            {
                rigidbody = GetComponent<Rigidbody>();
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
            rigidbody.MovePosition(Vector3.Lerp(rigidbody.position, _targetPosition, characterSettings.SmoothSpeed * Time.fixedDeltaTime));
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
    }
}
