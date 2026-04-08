using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Systems
{
    public class BaseWorldProvider : IWorldProvider
    {
        protected readonly IProtoAspect Aspect;
        protected readonly ProtoWorld World;

        public BaseWorldProvider(IProtoAspect aspect)
        {
            Aspect = aspect;
            World = new ProtoWorld(aspect);
        }

        public virtual ProtoWorld GetWorld() => World;
    }
}