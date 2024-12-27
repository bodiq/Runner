using System;
using Data;
using SaveData;
using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public class GameManager : IDisposable, Zenject.IInitializable
    {
        public Action OnCharacterDead;
        public Action<int> OnGameScoreChange;

        public Action OnGameStart;
        public Action OnGameEnd;

        private GameDataHandler _gameDataHandler;
        public GameResults gameResults;
        
        public void Dispose()
        {
            _gameDataHandler.SaveResults(gameResults);
        }

        public void Initialize()
        {
            Debug.Log("GameManager Initialize called");
            _gameDataHandler = new GameDataHandler();
            gameResults = _gameDataHandler.LoadResult();
        }
    }
}