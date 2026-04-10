using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Tests.Shared
{
    public class SystemsContainerProvider : ISystemsContainerProvider
    {
        public EcsSystems GetSystemsContainer()
        {
            var world = new ProtoWorld(new DomainAspect());
            var systems = new EcsSystems(world);
            systems.AddWorld(new ProtoWorld(new RequestsAspect()), RequestsContracts.RequestsIdentifier);

            systems.AddModule(new AutoInjectModule());
            
            return systems;
        }
    }
}