using Leopotam.EcsProto;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Features
{
    public abstract class BaseFeatureInstaller : IFeatureInstaller
    {
        public void InstallBindings(DiContainer container)
        {
            BindServices(container);
            RegisterBindings(container);
        }

        protected virtual void BindServices(DiContainer container) {}
        
        protected virtual void RegisterBindings(DiContainer container) {}

        public virtual void AddSystems(ProtoSystems systems) {}
    }
}