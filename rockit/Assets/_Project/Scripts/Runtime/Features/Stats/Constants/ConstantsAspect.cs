using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Components;
using _Project.Scripts.Runtime.Features.Economy.Coins.Components;
using _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Tags;
using _Project.Scripts.Runtime.Features.Physics.Shared.Components;
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
        public readonly ProtoPool<ConstantImproverTag> ImproveConstantTagPool;
        public readonly ProtoIt Constants = new (It.Inc<ConstantComponent>());
        public readonly ProtoIt ConstantActiveDisplays = new (It.Inc<ConstantActiveDisplayTag>());
        public readonly ProtoIt InvestigatedConstants = new (It.Inc<InvestigatedConstantTag>());
        public readonly ProtoIt PlayerLocatorConstantDisplays = new (It.Inc<PlayerLocatorComponent, ConstantDisplayTag>());
        public readonly ProtoIt ConstantActiveDisplayConstantPlayerLocators = new (It.Inc<ConstantActiveDisplayTag, ConstantComponent, PlayerLocatorComponent>());
        public readonly ProtoIt CoinsAmountConstantsImprovers = new (It.Inc<CoinsAmountComponent, ConstantImproverTag>());
        public readonly ProtoIt ClickedConstantsImprovers = new (It.Inc<ClickedTag, ConstantImproverTag>());
        public readonly ProtoIt ConstantColliders = new (It.Inc<ConstantComponent, Collider2DComponent>());
    }
}