using System.Linq;
using Data;
using Managers;
using UnityEngine;
using Zenject;

namespace Character
{
    public class CharacterMain : MonoBehaviour
    {
        [SerializeField] private CharacterMovement characterMovement;
        [SerializeField] private CharacterAnimator characterAnimator;
        
        public CharacterAnimator CharacterAnimator => characterAnimator;

        public int GameScore { get; set; }
        
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void OnEnable()
        {
            _gameManager.OnCharacterDead += CharacterDie;
            _gameManager.OnGameScoreChange += ChangeGameScore;
            _gameManager.OnGameStart += SpawnCharacter;
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
        }

        private void SetNewGameResult()
        {
            var results = _gameManager.gameResults.results;
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
            _gameManager.OnCharacterDead -= CharacterDie;
            _gameManager.OnGameScoreChange -= ChangeGameScore;
            _gameManager.OnGameStart -= SpawnCharacter;
        }
    }
}
 