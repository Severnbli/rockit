using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Base
{
    public interface IFeatureInstaller
    {
        void BindSystems(DiContainer container);
        void BindNonSystems(DiContainer container);
    }
}