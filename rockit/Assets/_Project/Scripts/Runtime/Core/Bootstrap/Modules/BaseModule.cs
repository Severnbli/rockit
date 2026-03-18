using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules
{
    public abstract class BaseModule<T> : Installer<T> 
        where T : BaseModule<T>
    {
        protected readonly EcsSystems Systems;
        protected readonly PausableSystemsSolver PausableSystemsSolver;
        protected readonly HashSet<IProtoSystem> PausableSystems = new();
        
        public BaseModule(EcsSystems systems, PausableSystemsSolver pausableSystemsSolver)
        {
            Systems = systems;
            PausableSystemsSolver = pausableSystemsSolver;
        }
        
        public sealed override void InstallBindings()
        {
            BindServices();
            RegisterBindings();
            InstallSystems();
        }

        private void InstallSystems()
        {
            BindSystems();

            if (!PausableSystems.Any()) return;

            Systems.AddSystem(new PausableSystems(PausableSystemsSolver, PausableSystems.ToArray()));
        }

        protected virtual void BindServices() {}

        public void BindService<TService>() where TService : class
        {
            Container.Bind<TService>().ToSelf().AsSingle();
        }
        
        protected virtual void RegisterBindings() {}

        protected virtual void BindSystems() {}

        public bool TryAddSystem<Tk>(bool pausable = false) where Tk : IProtoSystem
        {
            if (!TryInstantiateSystem<Tk>(out var system)) return false;

            if (pausable)
            {
                PausableSystems.Add(system);
            }
            else
            {
                Systems.AddSystem(system);
            }
            
            return true;
        }

        protected bool TryInstantiateSystem<Tk>(out IProtoSystem system) where Tk : IProtoSystem
        {
            system = Container.Instantiate<Tk>();
            return system is not null;
        }
    }
}