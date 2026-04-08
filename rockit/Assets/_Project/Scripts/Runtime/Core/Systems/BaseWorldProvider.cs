using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Systems
{
    public class BaseWorldProvider : IWorldProvider
    {
        protected readonly IProtoAspect Aspect;
        private readonly ProtoWorld _world;

        public BaseWorldProvider(IProtoAspect aspect)
        {
            Aspect = aspect;
            _world = new ProtoWorld(aspect);
        }

        public virtual ProtoWorld GetWorld() => _world;
    }
}