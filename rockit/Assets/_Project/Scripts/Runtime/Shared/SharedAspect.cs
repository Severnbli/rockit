using _Project.Scripts.Runtime.Shared.Components;
using _Project.Scripts.Runtime.Shared.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Shared
{
    public class SharedAspect : ProtoAspectInject
    {
        public ProtoPool<PlayerTag> PlayerTagPool;
        public ProtoPool<TransformComponent> TransformComponentPool;
        public ProtoPool<Rigidbody2DComponent> Rigidbody2DComponentPool;
        public ProtoIt Rigidbody2DPlayers = new (It.Inc<PlayerTag, Rigidbody2DComponent>());
        public ProtoIt Players = new (It.Inc<PlayerTag>());
    }
}