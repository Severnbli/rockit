using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests
{
    public class RequestsAspect : ProtoAspectInject
    {
        public ProtoPool<RequestComponent> RequestComponentPool;
    }
}