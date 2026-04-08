using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests
{
    public class RequestsWorldInstaller : IWorldInstaller
    {
        private readonly RequestsWorldAspect _aspect;
        private readonly ProtoWorld _world;

        public RequestsWorldInstaller(RequestsWorldAspect aspect)
        {
            _aspect = aspect;
            _world = new ProtoWorld(aspect);
        }

        public void Install(EcsSystems systems)
        {
            
        }
    }
}