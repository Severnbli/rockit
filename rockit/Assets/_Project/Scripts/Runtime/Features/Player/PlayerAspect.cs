using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Tags;
using _Project.Scripts.Runtime.Features.Physics.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Player
{
    public sealed class PlayerAspect : ProtoAspectInject
    {
        public ProtoIt Players = new (It.Inc<PlayerTag>());
        public ProtoIt TransformPlayers = new (It.Inc<PlayerTag, TransformComponent>());
        public ProtoIt ColliderPlayers = new (It.Inc<PlayerTag, Collider2DComponent>());
    }
}