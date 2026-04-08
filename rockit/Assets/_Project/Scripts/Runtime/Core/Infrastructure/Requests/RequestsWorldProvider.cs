using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests
{
    public class RequestsWorldProvider : IWorldProvider
    {
        private readonly RequestsAspect _aspect;
        private readonly ProtoWorld _world;

        public RequestsWorldProvider(RequestsAspect aspect)
        {
            _aspect = aspect;
            _world = new ProtoWorld(aspect);
        }

        public ProtoWorld GetWorld()
        {
            return null;
        }
    }
}