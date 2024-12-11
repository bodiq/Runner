using TMPro;
using UnityEngine;

namespace UI
{
    public class RankingRow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI gamePlayedText;
        [SerializeField] private TextMeshProUGUI scoreText;

        public void Initialize(int gamePlayed, int score)
        {
            gamePlayedText.text = gamePlayed.ToString();
            scoreText.text = score.ToString();
        }
    }
}
