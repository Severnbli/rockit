using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Tags;
using _Project.Scripts.Runtime.Features.Physics.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Shared
{
    public class PhysicsSharedAspect : ProtoAspectInject
    {
        public readonly ProtoPool<Collider2DComponent> Collider2DComponentPool;
        public readonly ProtoPool<Rigidbody2DComponent> Rigidbody2DComponentPool;
        public readonly ProtoIt Rigidbody2DPlayers = new (It.Inc<PlayerTag, Rigidbody2DComponent>());
        public readonly ProtoIt Rigidbody2DCharacters = new (It.Inc<CharacterTag, Rigidbody2DComponent>());
        public readonly ProtoIt Rigidbody2DColliders2D = new (It.Inc<Rigidbody2DComponent, Collider2DComponent>());
        public readonly ProtoIt Rigidbodies2D = new(It.Inc<Rigidbody2DComponent>());
    }
}