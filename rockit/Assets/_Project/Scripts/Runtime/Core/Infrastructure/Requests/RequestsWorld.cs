using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests
{
    public class RequestsWorld : ProtoWorld
    {
        public RequestsWorld() : base(new DomainAspect())
        {
        }

        public void AddToSystems(EcsSystems systems)
        {
            systems.AddWorld(this, RequestsContracts.Requests);
        }
    }
}