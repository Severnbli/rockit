using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Features
{
    public abstract class BaseFeatureInstaller<T> : Installer<T> 
        where T : BaseFeatureInstaller<T>
    {
        protected readonly EcsSystems Systems;
        protected readonly PausableSystemsSolver PausableSystemsSolver;
        protected readonly HashSet<IProtoSystem> PausableSystems = new();
        
        public BaseFeatureInstaller(EcsSystems systems, PausableSystemsSolver pausableSystemsSolver)
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
            AddSystems();

            if (!PausableSystems.Any()) return;

            Systems.AddSystem(new PausableSystems(PausableSystemsSolver, PausableSystems.ToArray()));
        }

        protected virtual void BindServices() {}
        
        protected virtual void RegisterBindings() {}

        public virtual void AddSystems() {}

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