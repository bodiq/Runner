using System.Linq;
using Data;
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
            GameManager.Instance.OnGameStart += SpawnCharacter;
        }

        private void SpawnCharacter()
        {
            transform.position = Vector3.zero;
            GameScore = 0;
        }

        private void CharacterDie()
        {
            SetNewGameResult();
            
            characterMovement.StopMoving();
            characterAnimator.SetIdleState();
        }

        private void SetNewGameResult()
        {
            var results = GameManager.Instance.gameResults.results;
            var lastGameCount = results.Any() ? results.Last().gameCount : 0;

            var newResult = new GameResult
            {
                gameCount = lastGameCount + 1,
                gameScore = GameScore
            };
            
            results.Add(newResult);
        }

        private void ChangeGameScore(int addNum)
        {
            GameScore += addNum;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnCharacterDead -= CharacterDie;
            GameManager.Instance.OnGameScoreChange -= ChangeGameScore;
            GameManager.Instance.OnGameStart -= SpawnCharacter;
        }
    }
}
 