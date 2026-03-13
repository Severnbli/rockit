using _Project.Scripts.Runtime.Core.Engine;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public class BaseDomain : MonoInstaller
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
            Container.Bind<MonoEngine>().FromNewComponentOn(gameObject).AsSingle().NonLazy();
        }
    }
}