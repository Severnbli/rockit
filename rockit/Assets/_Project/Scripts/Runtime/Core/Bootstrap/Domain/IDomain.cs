using _Project.Scripts.Runtime.Core.Bootstrap.Features;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public interface IDomain
    {
        void TryInstallFeature<T>() where T : IFeatureInstaller;
    }
}