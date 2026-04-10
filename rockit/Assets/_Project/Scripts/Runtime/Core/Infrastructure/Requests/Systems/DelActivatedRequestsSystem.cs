using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests.Systems
{
    public class DelActivatedRequestsSystem : IProtoRunSystem, IProtoFixedRunSystem
    {
        [DIRequests] private CoreRequestsAspect _coreRequestsAspect;
        
        public void Run()
        {
            foreach (var e in _coreRequestsAspect.RunActivated)
            {
                _coreRequestsAspect.World().DelEntity(e);
            }
        }

        public void FixedRun()
        {
            foreach (var e in _coreRequestsAspect.FixedRunActivated)
            {
                _coreRequestsAspect.World().DelEntity(e);
            }
        }
    }
}