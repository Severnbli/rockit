using _Project.Scripts.Runtime.Core.Bootstrap.Features;
using _Project.Scripts.Runtime.Core.Engine;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public abstract class BaseDomain : MonoInstaller, IDomain
    {
        protected readonly ProtoWorld World;
        protected readonly EcsSystems Systems;

        public BaseDomain(ProtoWorld world)
        {
            World = world;
            Systems = new EcsSystems(world);
        }
        
        public sealed override void InstallBindings()
        {
            Container.Bind<ProtoWorld>().FromInstance(World).AsSingle();
            Container.Bind<EcsSystems>().FromInstance(Systems).AsSingle();
            Container.Bind<MonoEngine>().FromNewComponentOn(gameObject).AsSingle().NonLazy();
        }

        public void TryInstallFeature<T>() where T : IFeatureInstaller
        {
            throw new System.NotImplementedException();
        }
    }
}