using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class ApplyJumpOnJumpRequestSystem : IProtoInitSystem, IProtoFixedRunSystem
    {
        [DI] private readonly MovingAspect _movingAspect;
        [DI] private readonly PhysicsSharedAspect _physicsSharedAspect;
        [DIRequests] private readonly MovingRequestsAspect _movingRequestsAspect;
        [DIRequests] private readonly CoreRequestsAspect _coreRequestsAspect;
        private ProtoWorld _world;
        private readonly TimeService _timeService;

        public ApplyJumpOnJumpRequestSystem(TimeService timeService)
        {
            _timeService = timeService;
        }

        public void Init(IProtoSystems systems)
        {
            _world = _movingAspect.World();
        }
        
        public void FixedRun()
        {
            
        }
    }
}