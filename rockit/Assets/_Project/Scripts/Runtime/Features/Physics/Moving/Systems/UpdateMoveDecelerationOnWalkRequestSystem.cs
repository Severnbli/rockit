using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public class UpdateMoveDecelerationOnWalkRequestSystem : IProtoInitSystem, IProtoFixedRunSystem
    {
        [DIRequests] private readonly MovingRequestsAspect _mrAspect;
        
        public void Init(IProtoSystems systems)
        {
            
        }

        public void FixedRun()
        {
            
        }
    }
}