using System;
using Character;
using Configs;
using Data;
using SaveData;
using UnityEngine;


namespace Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private CharacterMain character;

        public Action OnCharacterDead;
        public Action<int> OnGameScoreChange;

        public Action OnGameStart;
        public Action OnGameEnd;

        public CharacterMain Character => character;

        private GameDataHandler _gameDataHandler;

        public GameResults gameResults;

        protected override void Awake()
        {
            base.Awake();
            _gameDataHandler = new GameDataHandler();
            gameResults = _gameDataHandler.LoadResult();
        }

        private void OnApplicationQuit()
        {
            _gameDataHandler.SaveResults(gameResults);
        }
    }
}