using System;
using Configs;
using UI;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoSingleton<UIManager>
    {
        [SerializeField] private GameObject gamePlayUIObjects;
        [SerializeField] private GameObject lobbyUIObjects;
        [SerializeField] private HUDScreen hudScreen;

        public HUDScreen HUDScreen => hudScreen;

        private void OnEnable()
        {
            GameManager.Instance.OnGameEnd += TurnOnLobby;
            GameManager.Instance.OnGameStart += TurnOnGamePlay;
        }

        private void TurnOnGamePlay()
        {
            gamePlayUIObjects.SetActive(true);
            lobbyUIObjects.SetActive(false);
            HUDScreen.TurnTip(true);
        }

        public void TurnOnLobby()
        {
            gamePlayUIObjects.SetActive(false);
            lobbyUIObjects.SetActive(true);
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameEnd -= TurnOnLobby;
            GameManager.Instance.OnGameStart -= TurnOnGamePlay;
        }
    }
}
