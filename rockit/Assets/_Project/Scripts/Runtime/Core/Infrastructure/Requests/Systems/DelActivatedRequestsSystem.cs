using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests.Systems
{
    public class DelActivatedRequestsSystem : IProtoRunSystem, IProtoFixedRunSystem
    {
        [DIRequests] private RequestsAspect _requestsAspect;
        
        public void Run()
        {
            foreach (var e in _requestsAspect.RunActivated)
            {
                _requestsAspect.World().DelEntity(e);
            }
        }

        public void FixedRun()
        {
            foreach (var e in _requestsAspect.FixedRunActivated)
            {
                _requestsAspect.World().DelEntity(e);
            }
        }
    }
}