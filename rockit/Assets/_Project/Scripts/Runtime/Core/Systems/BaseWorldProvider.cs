using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Systems
{
    public class BaseWorldProvider : IWorldProvider
    {
        private readonly IProtoAspect _aspect;
        private readonly ProtoWorld _world;

        public BaseWorldProvider(IProtoAspect aspect)
        {
            _aspect = aspect;
            _world = new ProtoWorld(aspect);
        }

        public ProtoWorld GetWorld() => _world;
    }
}