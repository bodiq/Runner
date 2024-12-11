using System;
using Character;
using Configs;
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
    }
}