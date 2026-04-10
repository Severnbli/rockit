using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests
{
    public class CoreRequestsAspect : ProtoAspectInject
    {
        public ProtoPool<RequestComponent> RequestComponentPool;
        public ProtoPool<ActiveRequestTag> ActiveRequestTagPool;
        public ProtoPool<RunRequestTag> RunRequestTagPool;
        public ProtoPool<FixedRunRequestTag> FixedRunRequestTagPool;
        public ProtoItExc RunNotActivated = new(It.Inc<RequestComponent, RunRequestTag>(), It.Exc<ActiveRequestTag>());
        public ProtoItExc FixedRunNotActivated = new(It.Inc<RequestComponent, FixedRunRequestTag>(), It.Exc<ActiveRequestTag>());
        public ProtoIt RunActivated = new(It.Inc<RequestComponent, RunRequestTag, ActiveRequestTag>());
        public ProtoIt FixedRunActivated = new(It.Inc<RequestComponent, FixedRunRequestTag, ActiveRequestTag>());
    }
}