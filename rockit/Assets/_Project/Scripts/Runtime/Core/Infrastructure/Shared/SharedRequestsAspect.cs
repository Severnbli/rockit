using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared
{
    public sealed class SharedRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<InitializeRequest> InitializeRequestPool;
        public readonly ProtoPool<CloseAppRequest> CloseAppRequestPool;
        public readonly ProtoPool<DisableRequest> DisableRequestPool;
        public readonly ProtoPool<EnableRequest> EnableRequestPool;
        public readonly ProtoIt InitializeRunRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, InitializeRequest>());
        public readonly ProtoIt InitializeFixedRunRequests = new (It.Inc<RequestComponent, ActiveRequestTag, FixedRunRequestTag, InitializeRequest>());
        public readonly ProtoIt CloseAppRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, CloseAppRequest>());
        public readonly ProtoIt DisableRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, DisableRequest>());
        public readonly ProtoIt EnableRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, EnableRequest>());
    }
}