using Leopotam.EcsProto;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Features
{
    public interface IFeatureInstaller
    {
        void InstallBindings(DiContainer container);
        void AddSystems(ProtoSystems systems);
    }
}