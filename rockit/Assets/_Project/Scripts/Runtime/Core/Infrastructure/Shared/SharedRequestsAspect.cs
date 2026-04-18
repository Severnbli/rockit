using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared
{
    public class SharedRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<InitializeRequest> InitializeRequestPool;
        public readonly ProtoIt InitializeRunRequests = new(It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, InitializeRequest>());
        public readonly ProtoIt InitializeFixedRunRequests = new(It.Inc<RequestComponent, ActiveRequestTag, FixedRunRequestTag, InitializeRequest>());
    }
}