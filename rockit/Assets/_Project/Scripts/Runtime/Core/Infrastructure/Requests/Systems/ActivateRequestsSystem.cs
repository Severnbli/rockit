using System;
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
            foreach (var e in _requestsAspect.RunNotActivated)
            {
                _requestsAspect.ActiveRequestTagPool.Add(e);
            }
        }

        public void FixedRun()
        {
            foreach (var e in _requestsAspect.FixedRunNotActivated)
            {
                _requestsAspect.ActiveRequestTagPool.Add(e);
            }
        }
    }
}