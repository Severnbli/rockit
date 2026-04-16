using _Project.Scripts.Runtime.Features.Physics.Moving.Components;
using _Project.Scripts.Runtime.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving
{
    public class MovingAspect : ProtoAspectInject
    {
        public ProtoPool<GroundCheckComponent> GroundCheckComponentPool;
        public ProtoPool<GroundCheckResultComponent> GroundCheckResultComponentPool;
        public ProtoIt GroundCheckable = new (It.Inc<TransformComponent, GroundCheckComponent>());
        public ProtoIt Rigidbody2DGroundCheckResults = new (It.Inc<Rigidbody2DComponent, GroundCheckResultComponent>());
    }
}