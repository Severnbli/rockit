using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Components;
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
        public readonly ProtoIt GroundCheckable = new (It.Inc<TransformComponent, GroundCheckComponent>());
        public readonly ProtoIt Rigidbody2DGroundCheckResults = new (It.Inc<Rigidbody2DComponent, GroundCheckResultComponent>());
        public readonly ProtoIt JumpBufferingGroundCheckResults = new (It.Inc<JumpBufferingComponent, GroundCheckResultComponent>());
        public readonly ProtoIt JumpBuffers = new (It.Inc<JumpBufferingComponent>());
        public readonly ProtoIt DashTimeouts = new ProtoIt(It.Inc<DashTimeoutComponent>());
        public readonly ProtoIt DashGroundCheckResults = new (It.Inc<DashComponent, GroundCheckResultComponent>());
        public readonly ProtoItExc Dashables = new (It.Inc<Rigidbody2DComponent, GroundCheckResultComponent, MovableTag>(), It.Exc<DashTimeoutComponent>());
        public readonly ProtoIt Jumpables = new (It.Inc<Rigidbody2DComponent, GroundCheckResultComponent, MovableTag>());
        public readonly ProtoItExc Deceleratables = new (It.Inc<Rigidbody2DComponent, MoveComponent>(), It.Exc<DashTimeoutComponent>());
        public readonly ProtoItExc MoveSnapCreatables = new (It.Inc<GroundCheckResultComponent, Rigidbody2DComponent>(), It.Exc<MoveSnapComponent>());
        public readonly ProtoIt MoveSnapRemovables = new (It.Inc<GroundCheckResultComponent, MoveSnapComponent>());
    }
}