using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Tests
{
    public class SystemsContainerProvider : ISystemsContainerProvider
    {
        public EcsSystems GetSystemsContainer()
        {
            var world = new ProtoWorld(new DomainAspect());
            var systems = new EcsSystems(world);

            systems.AddModule(new AutoInjectModule());
            
            return systems;
        }
    }
}