using System;
using Configs;
using Data;
using SaveData;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public Action OnCharacterDead;
        public Action<int> OnGameScoreChange;

        public Action OnGameStart;
        public Action OnGameEnd;

        private GameDataHandler _gameDataHandler;

        public GameResults gameResults;

        private void Awake()
        {
            _gameDataHandler = new GameDataHandler();
            gameResults = _gameDataHandler.LoadResult();
        }

        private void OnApplicationQuit()
        {
            _gameDataHandler.SaveResults(gameResults);
        }
    }
}