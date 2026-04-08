using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests
{
    public class RequestsWorldInstaller : IWorldInstaller
    {
        private readonly RequestsWorldAspect _aspect;

        public RequestsWorldInstaller(RequestsWorldAspect aspect)
        {
            _aspect = aspect;
        }

        public void Install(EcsSystems systems)
        {
            
        }
    }
}