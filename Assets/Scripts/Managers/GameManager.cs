using System;
using Character;
using Configs;
using Unity.VisualScripting;
using UnityEngine;


namespace Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private CharacterMain character;

        public Action OnCharacterDead;

        public CharacterMain Character => character;
    }
}