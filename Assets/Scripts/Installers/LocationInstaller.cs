using Camera;
using Character;
using Managers;
using SaveData;
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
            BindCamera();
        }

        private void BindCamera()
        {
            Container.Bind<UnityEngine.Camera>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<CameraFollow>().AsCached();
        }

        private void BindManager()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsCached();
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