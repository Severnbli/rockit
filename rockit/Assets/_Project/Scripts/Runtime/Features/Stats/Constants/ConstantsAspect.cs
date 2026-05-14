using _Project.Scripts.Runtime.Features.Stats.Constants.Components;
using _Project.Scripts.Runtime.Features.Stats.Constants.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Stats.Constants
{
    public sealed class ConstantsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<ConstantComponent> ConstantComponentPool;
        public readonly ProtoPool<ConstantDisplayTag> ConstantDisplayTagPool;
        public readonly ProtoPool<ConstantActiveDisplayTag> ConstantActiveDisplayTagPool;
        public readonly ProtoPool<InvestigatedConstantTag> InvestigatedConstantTagPool;
        public readonly ProtoIt Constants = new (It.Inc<ConstantComponent>());
        public readonly ProtoIt ConstantActiveDisplays = new (It.Inc<ConstantActiveDisplayTag>());
        public readonly ProtoIt InvestigatedConstants = new (It.Inc<InvestigatedConstantTag>());
    }
}