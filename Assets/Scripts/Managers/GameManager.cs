using Character;
using Configs;
using UnityEngine;


namespace Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private CharacterMain character;

        public CharacterMain Character => character;
    }
}