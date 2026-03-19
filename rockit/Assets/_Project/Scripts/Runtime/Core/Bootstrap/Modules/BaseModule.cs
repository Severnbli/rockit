using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules
{
    public abstract class BaseModule<T> : Installer<SystemsBindResolver, T> 
        where T : BaseModule<T>
    {
        protected readonly SystemsBindResolver SystemsBindResolver;
        
        public BaseModule(SystemsBindResolver systemsBindResolver)
        {
            SystemsBindResolver = systemsBindResolver;
        }
        
        public sealed override void InstallBindings()
        {
            BindServices();
            RegisterBindings();
            BindSystems();
        }

        protected virtual void BindServices() {}

        public void BindService<TService>() where TService : class
        {
            Container.Bind<TService>().ToSelf().AsSingle();
        }
        
        protected virtual void RegisterBindings() {}

        protected virtual void BindSystems() {}

        public void BindSystem<TSystem>(bool pausable = false) where TSystem : IProtoSystem
        {
            Container
                .Bind<IProtoSystem>()
                .WithId(!pausable ? Contracts.NonPausableSystemsId : Contracts.PausableSystemsId)
                .To<TSystem>()
                .AsSingle()
                .WhenInjectedIntoInstance(SystemsBindResolver);
        }
    }
}