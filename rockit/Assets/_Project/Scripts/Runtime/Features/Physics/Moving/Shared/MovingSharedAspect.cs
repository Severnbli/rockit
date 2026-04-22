using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Components;
using _Project.Scripts.Runtime.Features.Physics.Moving.Shared.Components;
using _Project.Scripts.Runtime.Features.Physics.Moving.Shared.Tags;
using _Project.Scripts.Runtime.Features.Physics.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Shared
{
    public class MovingSharedAspect : ProtoAspectInject
    {
        public readonly ProtoPool<MoveComponent> MoveComponentPool;
        public readonly ProtoPool<MovableTag> MovableTagPool;
        public readonly ProtoPool<MoveSnapComponent> MoveSnapComponentPool;
        public readonly ProtoItExc Walkables = new (It.Inc<Rigidbody2DComponent, MovableTag>(), It.Exc<DashTimeoutComponent>());
        public readonly ProtoIt Movables = new (It.Inc<MovableTag>());
        public readonly ProtoIt Rigidbody2DMovables = new (It.Inc<Rigidbody2DComponent, MovableTag>());
        public readonly ProtoIt MoveSnaps = new (It.Inc<MoveSnapComponent>());
    }
}