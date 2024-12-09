using UnityEngine;

namespace Character
{
    public class CharacterMain : MonoBehaviour
    {
        [SerializeField] private CharacterMovement characterMovement;
        [SerializeField] private CharacterAnimator characterAnimator;

        public CharacterMovement CharacterMovement => characterMovement;
        public CharacterAnimator CharacterAnimator => characterAnimator;
    }
}
 