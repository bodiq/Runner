using Managers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class HUDScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreCountText;

        private int _score = 0;
    
        private void OnEnable()
        {
            GameManager.Instance.OnGameScoreChange += ChangeScoreText;
            GameManager.Instance.OnCharacterDead += ResetHUDData;
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
            GameManager.Instance.OnGameScoreChange -= ChangeScoreText;
            GameManager.Instance.OnCharacterDead -= ResetHUDData;
        }
    }
}