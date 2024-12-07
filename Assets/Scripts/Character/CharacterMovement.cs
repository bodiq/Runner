using System;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterSettings characterSettings;
        [SerializeField] private Rigidbody rigidbody;

        private float _targetHorizontalPosition;
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
            var horizontal = Input.GetAxis("Horizontal");
            _targetHorizontalPosition += horizontal * characterSettings.SideSpeed * Time.deltaTime;
            _targetHorizontalPosition = Mathf.Clamp(_targetHorizontalPosition, -characterSettings.HorizontalLimit, characterSettings.HorizontalLimit);
        }

        private void FixedUpdate()
        {
            _targetPosition = new Vector3(_targetHorizontalPosition, transform.position.y, transform.position.z + characterSettings.ForwardSpeed * Time.fixedDeltaTime);
            rigidbody.MovePosition(Vector3.MoveTowards(rigidbody.position, _targetPosition, characterSettings.SmoothSpeed * Time.fixedDeltaTime));
        }
    }
}
