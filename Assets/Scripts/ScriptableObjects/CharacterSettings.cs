using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/CharacterSettings", fileName = "Character Settings")]
    public class CharacterSettings : ScriptableObject
    {
        [Header("Movement Settings")]
        [SerializeField] private float forwardSpeed;
        [SerializeField] private float sideSpeed;
        [SerializeField] private float horizontalLimit;
        [SerializeField] private float smoothSpeed;


        public float ForwardSpeed => forwardSpeed;
        public float SideSpeed => sideSpeed;
        public float HorizontalLimit => horizontalLimit;
        public float SmoothSpeed => smoothSpeed;
    }
}