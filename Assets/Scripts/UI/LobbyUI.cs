using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LobbyUI : MonoBehaviour
    {
        [SerializeField] private Button playGameButton;
        [SerializeField] private Button leaderboardButton;
        [SerializeField] private Button backButton;

        [SerializeField] private GameObject mainMenuBox;
        [SerializeField] private GameObject leaderboard;

        private void OnEnable()
        {
            playGameButton.onClick.AddListener(OnPlayButtonClick);
            leaderboardButton.onClick.AddListener(OnLeaderboardButtonClick);
            backButton.onClick.AddListener(OpenMainMenu);
        }

        private void OnPlayButtonClick()
        {
            GameManager.Instance.OnGameStart?.Invoke();
        }

        private void OnLeaderboardButtonClick()
        {
            mainMenuBox.SetActive(false);
            leaderboard.SetActive(true);
        }

        private void OpenMainMenu()
        {
            mainMenuBox.SetActive(true);
            leaderboard.SetActive(false);
        }

        private void OnDisable()
        {
            playGameButton.onClick.RemoveListener(OnPlayButtonClick);
            leaderboardButton.onClick.RemoveListener(OnLeaderboardButtonClick);
            backButton.onClick.RemoveListener(OpenMainMenu);
        }
    }
}
