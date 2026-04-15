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
    }
}