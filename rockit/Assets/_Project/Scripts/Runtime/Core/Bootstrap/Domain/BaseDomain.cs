using _Project.Scripts.Runtime.Core.Engine;
using Leopotam.EcsProto;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public class BaseDomain : MonoInstaller
    {
        protected ProtoWorld World;
        
        public sealed override void InstallBindings()
        {
            Container.Bind<MonoEngine>().FromNewComponentOn(gameObject).AsSingle().NonLazy();
        }
    }
}