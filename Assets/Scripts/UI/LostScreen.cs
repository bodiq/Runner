using DG.Tweening;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class LostScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Button returnToLobbyButton;
    
    private void OnEnable()
    {
        GameManager.Instance.OnCharacterDead += TurnOn;
        returnToLobbyButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        TurnOff();
        UIManager.Instance.TurnOnLobby();
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
        GameManager.Instance.OnCharacterDead -= TurnOn;
        returnToLobbyButton.onClick.RemoveListener(OnButtonClick);
    }
}
