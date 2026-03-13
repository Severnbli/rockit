using _Project.Scripts.Runtime.Core.Engine;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public class BaseDomain : MonoInstaller
    {
        public sealed override void InstallBindings()
        {
            Container.Bind<MonoEngine>().FromNewComponentOn(gameObject).AsSingle().NonLazy();
        }
    }
}