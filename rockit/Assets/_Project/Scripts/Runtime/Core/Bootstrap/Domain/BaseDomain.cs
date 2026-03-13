using _Project.Scripts.Runtime.Core.Engine;
using Leopotam.EcsProto;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public class BaseDomain : MonoInstaller
    {
        protected readonly ProtoWorld World;

        public BaseDomain(ProtoWorld world)
        {
            World = world;
        }
        
        public sealed override void InstallBindings()
        {
            Container.Bind<MonoEngine>().FromNewComponentOn(gameObject).AsSingle().NonLazy();
        }
    }
}