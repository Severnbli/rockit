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

        protected virtual void BindServices() {}
        
        protected virtual void RegisterBindings() {}

        public virtual void AddSystems() {}

        public bool TryAddSystem<Tk>() where Tk : IProtoSystem
        {
            var system = (IProtoSystem) Container.Instantiate<Tk>();
            if (system is null) return false;
            
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