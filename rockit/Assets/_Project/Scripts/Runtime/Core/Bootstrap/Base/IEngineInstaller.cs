using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Base
{
    public interface IEngineInstaller
    {
        void AddFeatureInstaller(IFeatureInstaller installer);
        void RegisterBindings(DiContainer container);
    }
}