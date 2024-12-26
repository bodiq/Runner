using System;
using Configs;
using UI;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class UIManager : MonoSingleton<UIManager>
    {
        [SerializeField] private GameObject gamePlayUIObjects;
        [SerializeField] private GameObject lobbyUIObjects;
        [SerializeField] private HUDScreen hudScreen;
        
        private GameManager _gameManager;

        public HUDScreen HUDScreen => hudScreen;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void OnEnable()
        {
            _gameManager.OnGameEnd += TurnOnLobby;
            _gameManager.OnGameStart += TurnOnGamePlay;
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
            _gameManager.OnGameEnd -= TurnOnLobby;
            _gameManager.OnGameStart -= TurnOnGamePlay;
        }
    }
}
