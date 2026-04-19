using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Components
{
    public class AnimationsSharedAspect : ProtoAspectInject
    {
        public readonly ProtoPool<AnimatorComponent> AnimatorComponentPool;
        public readonly ProtoIt Animators = new (It.Inc<AnimatorComponent>());
    }
}