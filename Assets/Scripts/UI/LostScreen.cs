using DG.Tweening;
using Managers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class LostScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Button returnToLobbyButton;
    
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        
        private void OnEnable()
        {
            _gameManager.OnCharacterDead += TurnOn;
            returnToLobbyButton.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            TurnOff();
            _gameManager.OnGameEnd?.Invoke();
        }

        private void TurnOn()
        {
            canvasGroup.DOFade(1f, 0.3f);
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        private void TurnOff()
        {
            canvasGroup.DOFade(0f, 0.1f);
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        private void OnDisable()
        {
            _gameManager.OnCharacterDead -= TurnOn;
            returnToLobbyButton.onClick.RemoveListener(OnButtonClick);
        }
    }
}
