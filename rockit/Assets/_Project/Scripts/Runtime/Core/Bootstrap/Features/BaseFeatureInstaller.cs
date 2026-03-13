using _Project.Scripts.Runtime.Core.Systems;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Features
{
    public abstract class BaseFeatureInstaller<T> : Installer<T> 
        where T : BaseFeatureInstaller<T>
    {
        protected readonly EcsSystems Systems;
        protected readonly PausableSystemsSolver PausableSystemsSolver;
        
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
    }
}