using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Components;
using _Project.Scripts.Runtime.Features.World.Checkpoints.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Checkpoints
{
    public sealed class CheckpointsAnimationsAspect : ProtoAspectInject
    {
        public readonly ProtoIt CheckpointAnimators = new (It.Inc<CheckpointComponent, AnimatorComponent>());
    }
}