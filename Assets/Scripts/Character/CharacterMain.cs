using System;
using Managers;
using UnityEngine;

namespace Character
{
    public class CharacterMain : MonoBehaviour
    {
        [SerializeField] private CharacterMovement characterMovement;
        [SerializeField] private CharacterAnimator characterAnimator;

        public CharacterMovement CharacterMovement => characterMovement;
        public CharacterAnimator CharacterAnimator => characterAnimator;

        private void OnEnable()
        {
            GameManager.Instance.OnCharacterDead += CharacterDie;
        }

        private void CharacterDie()
        {
            characterMovement.StopMoving();
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            GameManager.Instance.OnCharacterDead -= CharacterDie;
        }
    }
}
 