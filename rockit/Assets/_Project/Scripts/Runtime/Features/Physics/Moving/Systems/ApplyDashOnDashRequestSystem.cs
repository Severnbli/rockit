using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Moving.Components;
using _Project.Scripts.Runtime.Features.Physics.Moving.Requests;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class ApplyDashOnDashRequestSystem : IProtoInitSystem, IProtoFixedRunSystem
    {
        [DIRequests] private readonly MovingRequestsAspect _mrAspect;
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DI] private readonly MovingAspect _mAspect;
        [DI] private readonly PhysicsSharedAspect _psAspect;
        private ProtoWorld _world;
        private readonly TimeService _tService;

        public ApplyDashOnDashRequestSystem(TimeService tService)
        {
            _tService = tService;
        }

        public void Init(IProtoSystems systems)
        {
            _world = _mAspect.World();
        }
        
        public void FixedRun()
        {
            
        }
    }
}