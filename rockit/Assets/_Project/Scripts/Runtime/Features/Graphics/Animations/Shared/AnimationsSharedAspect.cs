using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Tags;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Checkpoints;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Constants;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Components;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Teleporters;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Shared
{
    public sealed class AnimationsSharedAspect : ProtoAspectInject
    {
        public readonly ConstantsAnimationsAspect ConstantsAnimationsAspect;
        public readonly CheckpointsAnimationsAspect CheckpointsAnimationsAspect;
        public readonly TeleportersAnimationsAspect TeleportersAnimationsAspect;
        
        public readonly ProtoPool<AnimatorComponent> AnimatorComponentPool;
        public readonly ProtoIt Animators = new (It.Inc<AnimatorComponent>());
        public readonly ProtoIt CharacterAnimators = new (It.Inc<AnimatorComponent, CharacterTag>());
    }
}