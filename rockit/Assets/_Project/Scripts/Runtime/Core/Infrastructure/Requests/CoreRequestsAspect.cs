using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests
{
    public sealed class CoreRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<RequestComponent> RequestComponentPool;
        public readonly ProtoPool<ActiveRequestTag> ActiveRequestTagPool;
        public readonly ProtoPool<RunRequestTag> RunRequestTagPool;
        public readonly ProtoPool<FixedRunRequestTag> FixedRunRequestTagPool;
        public readonly ProtoItExc RunNotActivated = new(It.Inc<RequestComponent, RunRequestTag>(), It.Exc<ActiveRequestTag>());
        public readonly ProtoItExc FixedRunNotActivated = new(It.Inc<RequestComponent, FixedRunRequestTag>(), It.Exc<ActiveRequestTag>());
        public readonly ProtoIt RunActivated = new(It.Inc<RequestComponent, RunRequestTag, ActiveRequestTag>());
        public readonly ProtoIt FixedRunActivated = new(It.Inc<RequestComponent, FixedRunRequestTag, ActiveRequestTag>());
    }
}