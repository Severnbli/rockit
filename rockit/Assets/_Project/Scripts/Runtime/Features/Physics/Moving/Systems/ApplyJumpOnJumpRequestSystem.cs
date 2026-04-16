using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Systems;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class ApplyJumpOnJumpRequestSystem : IProtoFixedRunSystem
    {
        [DIRequests] private readonly MovingRequestsAspect _movingRequestsAspect;
        
        public void FixedRun()
        {
            
        }
    }
}