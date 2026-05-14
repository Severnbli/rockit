using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Components;
using _Project.Scripts.Runtime.Features.Stats.Constants.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Constants
{
    public sealed class ConstantsAnimationsAspect : ProtoAspectInject 
    {
        public readonly ProtoIt ConstantDisplayAnimators = new (It.Inc<AnimatorComponent, ConstantDisplayTag>());
    }
}