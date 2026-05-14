using _Project.Scripts.Runtime.Features.Stats.Constants.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Stats.Constants
{
    public sealed class ConstantsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<ConstantComponent> ConstantComponentPool;
    }
}