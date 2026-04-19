using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Shared
{
    public class AnimationsSharedAspect : ProtoAspectInject
    {
        public readonly ProtoPool<AnimatorComponent> AnimatorComponentPool;
        public readonly ProtoIt Animators = new (It.Inc<AnimatorComponent>());
    }
}