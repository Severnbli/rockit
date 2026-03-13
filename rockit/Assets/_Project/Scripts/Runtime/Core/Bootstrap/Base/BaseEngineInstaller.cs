using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Base
{
    public class BaseEngineInstaller : MonoInstaller, IEngineInstaller
    {
        public void AddFeatureInstaller(IFeatureInstaller installer)
        {
            throw new System.NotImplementedException();
        }

        public void RegisterBindings(DiContainer container)
        {
            throw new System.NotImplementedException();
        }
    }
}