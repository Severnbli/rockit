using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared
{
    public class SharedAspect : ProtoAspectInject
    {
        public readonly ProtoPool<PlayerTag> PlayerTagPool;
        public readonly ProtoPool<TransformComponent> TransformComponentPool;
        public readonly ProtoPool<InitializableTag> InitializableTagPool;
        public readonly ProtoPool<CharacterTag> CharacterTagPool;
        public readonly ProtoPool<GameObjectComponent> GameObjectComponentPool;
        public readonly ProtoIt Players = new (It.Inc<PlayerTag>());
        public readonly ProtoIt Initializables = new (It.Inc<InitializableTag>());
        public readonly ProtoIt Characters = new (It.Inc<CharacterTag>());
        public readonly ProtoIt GameObjectComponents = new (It.Inc<GameObjectComponent>());
    }
}