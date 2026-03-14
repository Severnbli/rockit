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
        protected readonly HashSet<IProtoSystem> PausableSystems;
        
        public BaseFeatureInstaller(EcsSystems systems, PausableSystemsSolver pausableSystemsSolver)
        {
            Systems = systems;
            PausableSystemsSolver = pausableSystemsSolver;
        }
        
        public override void InstallBindings()
        {
            BindServices();
            RegisterBindings();
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

        public bool TryAddSystem<Tk>() where Tk : IProtoSystem
        {
            if (!TryInstantiateSystem<Tk>(out var system)) return false;
            Systems.AddSystem(system);
            return true;
        }

        public bool TryAddPausableSystem<Tk>() where Tk : IProtoSystem
        {
            if (!TryInstantiateSystem<Tk>(out var system)) return false;
            PausableSystems.Add(system);
            return true;
        }

        protected bool TryInstantiateSystem<Tk>(out IProtoSystem system) where Tk : IProtoSystem
        {
            system = Container.Instantiate<Tk>();
            return system is not null;
        }
    }
}