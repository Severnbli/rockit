using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Systems
{
    public class BaseWorldProvider : IWorldProvider
    {
        private readonly IProtoAspect _aspect;

        public BaseWorldProvider(IProtoAspect aspect)
        {
            _aspect = aspect;
        }

        public ProtoWorld GetWorld()
        {
            return null;
        }
    }
}