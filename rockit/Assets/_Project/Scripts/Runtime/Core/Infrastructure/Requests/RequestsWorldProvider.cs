using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests
{
    public class RequestsWorldProvider : IWorldProvider
    {
        private readonly RequestsAspect _aspect;

        public RequestsWorldProvider(RequestsAspect aspect)
        {
            _aspect = aspect;
        }

        public ProtoWorld GetWorld()
        {
            return null;
        }
    }
}