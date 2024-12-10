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

        public int GameScore { get; set; }

        private void OnEnable()
        {
            GameManager.Instance.OnCharacterDead += CharacterDie;
            GameManager.Instance.OnGameScoreChange += ChangeGameScore;
        }

        private void CharacterDie()
        {
            characterMovement.StopMoving();
            gameObject.SetActive(false);
        }

        private void ChangeGameScore(int addNum)
        {
            GameScore += addNum;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnCharacterDead -= CharacterDie;
        }
    }
}
 