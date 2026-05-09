using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Tags;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Components;
using _Project.Scripts.Runtime.Features.Physics.Moving.Shared.Components;
using _Project.Scripts.Runtime.Features.Physics.Moving.Shared.Tags;
using _Project.Scripts.Runtime.Features.Physics.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters
{
    public sealed class CharactersMovingAspect : ProtoAspectInject
    {
        public readonly ProtoPool<GroundCheckComponent> GroundCheckComponentPool;
        public readonly ProtoPool<GroundCheckResultComponent> GroundCheckResultComponentPool;
        public readonly ProtoPool<JumpBufferingComponent> JumpBufferingComponentPool;
        public readonly ProtoPool<DashTimeoutComponent> DashTimeoutComponentPool;
        public readonly ProtoPool<DashComponent> DashComponentPool;
        public readonly ProtoPool<CharacterVelocityComponent> CharacterVelocityComponentPool;
        public readonly ProtoPool<CharacterMoveComponent> CharacterMoveComponentPool;
        public readonly ProtoPool<CharacterImpactedVelocityComponent> CharacterImpactedVelocityComponentPool;
        public readonly ProtoIt GroundCheckable = new (It.Inc<TransformComponent, GroundCheckComponent>());
        public readonly ProtoIt GroundCheckResults = new (It.Inc<GroundCheckResultComponent>());
        public readonly ProtoIt Rigidbody2DCharactersImpactedVelocities = new (It.Inc<Rigidbody2DComponent, CharacterImpactedVelocityComponent>());
        public readonly ProtoIt JumpBufferingGroundCheckResults = new (It.Inc<JumpBufferingComponent, GroundCheckResultComponent>());
        public readonly ProtoIt JumpBuffers = new (It.Inc<JumpBufferingComponent>());
        public readonly ProtoIt DashTimeouts = new ProtoIt(It.Inc<DashTimeoutComponent>());
        public readonly ProtoItExc Walkables = new (It.Inc<CharacterTag, MovableTag>(), It.Exc<DashTimeoutComponent>());
        public readonly ProtoIt DashGroundCheckResults = new (It.Inc<DashComponent, GroundCheckResultComponent>());
        public readonly ProtoItExc Dashables = new (It.Inc<CharacterTag, GroundCheckResultComponent, MovableTag>(), It.Exc<DashTimeoutComponent>());
        public readonly ProtoIt Jumpables = new (It.Inc<CharacterTag, GroundCheckResultComponent, MovableTag>());
        public readonly ProtoItExc WalkDeceleratables = new (It.Inc<CharacterMoveComponent, CharacterVelocityComponent>(), It.Exc<DashTimeoutComponent>());
        public readonly ProtoItExc JumpDeceleratables = new (It.Inc<CharacterMoveComponent>(), It.Exc<DashTimeoutComponent>());
        public readonly ProtoItExc MoveSnapCreatables = new (It.Inc<GroundCheckResultComponent, Rigidbody2DComponent>(), It.Exc<MoveSnapComponent>());
        public readonly ProtoIt MoveSnapRemovables = new (It.Inc<GroundCheckResultComponent, MoveSnapComponent>());
        public readonly ProtoIt CharacterVelocities = new (It.Inc<CharacterVelocityComponent>());
        public readonly ProtoIt GroundCheckResultCharacterVelocities = new (It.Inc<GroundCheckResultComponent, CharacterVelocityComponent>());
    }
}