using Character;
using Managers;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class LocationInstaller : MonoInstaller
    {
        public Transform spawnPoint;
        public GameObject playerPrefab;
        
        public override void InstallBindings()
        {
            BindManager();
            BindCharacter();
        }

        private void BindManager()
        {
            Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
        }

        private void BindCharacter()
        {
            var character = Container.InstantiatePrefabForComponent<CharacterMain>(playerPrefab, spawnPoint.position, Quaternion.identity, null);

            Container
                .Bind<CharacterMain>()
                .FromInstance(character)
                .AsSingle();
        }
    }
}