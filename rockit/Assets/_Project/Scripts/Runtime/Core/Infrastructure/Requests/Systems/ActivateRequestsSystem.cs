using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests.Systems
{
    public class ActivateRequestsSystem : IProtoRunSystem, IProtoFixedRunSystem
    {
        [DI] private RequestsAspect _requestsAspect;
        
        public void Run()
        {
            throw new System.NotImplementedException();
        }

        public void FixedRun()
        {
            throw new System.NotImplementedException();
        }
    }
}