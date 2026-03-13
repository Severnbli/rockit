using _Project.Scripts.Runtime.Core.Systems;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Features
{
    public abstract class BaseFeatureInstaller : IFeatureInstaller
    {
        protected readonly DiContainer Container;
        protected readonly EcsSystems Systems;
        protected readonly PausableSystemsSolver PausableSystemsSolver;
        
        public BaseFeatureInstaller(DiContainer container, EcsSystems systems, PausableSystemsSolver pausableSystemsSolver)
        {
            Container = container;
            Systems = systems;
            PausableSystemsSolver = pausableSystemsSolver;
        }
        
        public void InstallBindings()
        {
            BindServices();
            RegisterBindings();
        }

        protected virtual void BindServices() {}
        
        protected virtual void RegisterBindings() {}

        public virtual void AddSystems() {}
    }
}