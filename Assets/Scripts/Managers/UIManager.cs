using System;
using Configs;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoSingleton<UIManager>
    {
        [SerializeField] private GameObject gamePlayUIObjects;
        [SerializeField] private GameObject lobbyUIObjects;

        private void OnEnable()
        {
            GameManager.Instance.OnGameEnd += TurnOnLobby;
            GameManager.Instance.OnGameStart += TurnOnGamePlay;
        }

        private void TurnOnGamePlay()
        {
            gamePlayUIObjects.SetActive(true);
            lobbyUIObjects.SetActive(false);
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
