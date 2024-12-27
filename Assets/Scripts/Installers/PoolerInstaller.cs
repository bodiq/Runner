using Data;
using Managers;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PoolerInstaller : MonoInstaller
    {
        [SerializeField] private PoolData poolData;
            
        public override void InstallBindings()
        {
            BindPooler();
        }

        private void BindPooler()
        {
            Container.BindInterfacesAndSelfTo<ObjectPoolManager>().AsCached().WithArguments(poolData);
        }
    }
}