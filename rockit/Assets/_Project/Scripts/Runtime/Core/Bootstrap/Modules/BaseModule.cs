using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules
{
    public abstract class BaseModule<T> : Installer<T> 
        where T : BaseModule<T>
    {
        protected readonly EcsSystems Systems;
        
        public BaseModule(EcsSystems systems)
        {
            Systems = systems;
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

        public void BindSystem<TSystem>() where TSystem : IProtoSystem
        {
            Container.Bind<IProtoSystem>().To<TSystem>().AsSingle();
        }
    }
}