using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class ApplyJumpOnJumpRequestSystem : IProtoFixedRunSystem
    {
        [DI] private readonly MovingAspect _movingAspect;
        [DIRequests] private readonly MovingRequestsAspect _movingRequestsAspect;
        
        public void FixedRun()
        {
            
        }
    }
}