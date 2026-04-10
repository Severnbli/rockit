using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests.Systems
{
    public class ActivateRequestsSystem : IProtoRunSystem, IProtoFixedRunSystem
    {
        [DIRequests] private CoreRequestsAspect _coreRequestsAspect;
        
        public void Run()
        {
            foreach (var e in _coreRequestsAspect.RunNotActivated)
            {
                _coreRequestsAspect.ActiveRequestTagPool.Add(e);
            }
        }

        public void FixedRun()
        {
            foreach (var e in _coreRequestsAspect.FixedRunNotActivated)
            {
                _coreRequestsAspect.ActiveRequestTagPool.Add(e);
            }
        }
    }
}