using Leopotam.EcsProto;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Features
{
    public abstract class BaseFeatureInstaller : IFeatureInstaller
    {
        public void InstallBindings(DiContainer container)
        {
            throw new System.NotImplementedException();
        }

        public void AddSystems(ProtoSystems systems)
        {
            throw new System.NotImplementedException();
        }
    }
}