using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Tags;
using _Project.Scripts.Runtime.Features.Physics.Shared.Components;
using _Project.Scripts.Runtime.Shared.Callback.Events;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using Leopotam.EcsProto.Unity.Physics2D;

namespace _Project.Scripts.Runtime.Features.Physics.Shared
{
    public class PhysicsSharedAspect : ProtoAspectInject
    {
        public readonly ProtoPool<Collider2DComponent> Collider2DComponentPool;
        public readonly ProtoPool<Rigidbody2DComponent> Rigidbody2DComponentPool;
        public readonly ProtoPool<UnityPhysics2DCollisionEnterEvent> CollisionEnterEventPool;
        public readonly ProtoPool<UnityPhysics2DCollisionStayEvent> CollisionStayEventPool;
        public readonly ProtoPool<UnityPhysics2DCollisionExitEvent> CollisionExitEventPool;
        public readonly ProtoPool<UnityPhysics2DTriggerEnterEvent> TriggerEnterEventPool;
        public readonly ProtoPool<UnityPhysics2DTriggerExitEvent> TriggerExitEventPool;
        public readonly ProtoIt Rigidbody2DPlayers = new (It.Inc<PlayerTag, Rigidbody2DComponent>());
        public readonly ProtoIt Rigidbody2DCharacters = new (It.Inc<CharacterTag, Rigidbody2DComponent>());
        public readonly ProtoIt Rigidbody2DColliders2D = new (It.Inc<Rigidbody2DComponent, Collider2DComponent>());
        public readonly ProtoIt Rigidbodies2D = new(It.Inc<Rigidbody2DComponent>());
        public readonly ProtoIt CollisionEnterEvents = new (It.Inc<UnityPhysics2DCollisionEnterEvent>());
        public readonly ProtoIt CollisionStayEvents = new (It.Inc<UnityPhysics2DCollisionStayEvent>());
        public readonly ProtoIt CollisionExitEvents = new (It.Inc<UnityPhysics2DCollisionExitEvent>());
        public readonly ProtoIt TriggerEnterEvents = new (It.Inc<UnityPhysics2DTriggerEnterEvent>());
        public readonly ProtoIt TriggerExitEvents = new (It.Inc<UnityPhysics2DTriggerExitEvent>());
    }
}