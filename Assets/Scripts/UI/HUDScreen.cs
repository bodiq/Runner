using Managers;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class HUDScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreCountText;
        [SerializeField] private GameObject startGameTip;

        private int _score = 0;
        
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
    
        private void OnEnable()
        {
            _gameManager.OnGameScoreChange += ChangeScoreText;
            _gameManager.OnCharacterDead += ResetHUDData;
        }

        public void TurnTip(bool isActive)
        {
            startGameTip.gameObject.SetActive(isActive);
        }

        private void ChangeScoreText(int numToAdd)
        {
            _score += numToAdd;
            scoreCountText.text = _score.ToString();
        }

        private void ResetHUDData()
        {
            _score = 0;
            scoreCountText.text = _score.ToString();
        }

        private void OnDisable()
        {
            _gameManager.OnGameScoreChange -= ChangeScoreText;
            _gameManager.OnCharacterDead -= ResetHUDData;
        }
    }
}
