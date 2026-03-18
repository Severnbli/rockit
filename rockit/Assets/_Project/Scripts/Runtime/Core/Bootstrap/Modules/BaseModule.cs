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

        public bool TryAddSystem<Tk>() where Tk : IProtoSystem
        {
            if (!TryInstantiateSystem<Tk>(out var system)) return false;

            Systems.AddSystem(system);
            
            return true;
        }

        protected bool TryInstantiateSystem<Tk>(out IProtoSystem system) where Tk : IProtoSystem
        {
            system = Container.Instantiate<Tk>();
            return system is not null;
        }
    }
}