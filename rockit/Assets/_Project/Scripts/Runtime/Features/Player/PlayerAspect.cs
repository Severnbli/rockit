using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Player
{
    public sealed class PlayerAspect : ProtoAspectInject
    {
        public ProtoIt TransformPlayers = new (It.Inc<PlayerTag, TransformComponent>());
    }
}