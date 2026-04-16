using _Project.Scripts.Runtime.Features.Physics.Shared.Components;
using _Project.Scripts.Runtime.Shared.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Shared
{
    public class PhysicsSharedAspect : ProtoAspectInject
    {
        public ProtoPool<Collider2DComponent> Collider2DComponentPool;
        public ProtoPool<Rigidbody2DComponent> Rigidbody2DComponentPool;
        public ProtoIt Rigidbody2DPlayers = new (It.Inc<PlayerTag, Rigidbody2DComponent>());
        public ProtoIt Rigidbody2DColliders2D = new (It.Inc<Rigidbody2DComponent, Collider2DComponent>());
    }
}