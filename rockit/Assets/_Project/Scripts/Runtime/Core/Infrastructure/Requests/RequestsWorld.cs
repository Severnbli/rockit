using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests
{
    public class RequestsWorld : ProtoWorld
    {
        public RequestsWorld() : base(new DomainAspect())
        {
        }
    }
}