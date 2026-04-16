using _Project.Scripts.Runtime.Features.Physics.Moving.Components;
using _Project.Scripts.Runtime.Features.Physics.Shared.Components;
using _Project.Scripts.Runtime.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving
{
    public class MovingAspect : ProtoAspectInject
    {
        public readonly ProtoPool<GroundCheckComponent> GroundCheckComponentPool;
        public readonly ProtoPool<GroundCheckResultComponent> GroundCheckResultComponentPool;
        public readonly ProtoPool<JumpBufferingComponent> JumpBufferingComponentPool;
        public readonly ProtoIt GroundCheckable = new (It.Inc<TransformComponent, GroundCheckComponent>());
        public readonly ProtoIt Rigidbody2DGroundCheckResults = new (It.Inc<Rigidbody2DComponent, GroundCheckResultComponent>());
        public readonly ProtoIt JumpBufferingGroundCheckResults = new(It.Inc<JumpBufferingComponent, GroundCheckResultComponent>());
        public readonly ProtoIt JumpBuffers = new(It.Inc<JumpBufferingComponent>());
    }
}