namespace _Project.Scripts.Runtime.Core.Bootstrap.Features
{
    public abstract class BaseFeatureInstaller : IFeatureInstaller
    {
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