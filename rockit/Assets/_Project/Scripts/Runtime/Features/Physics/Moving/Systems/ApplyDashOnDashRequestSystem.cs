using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Moving.Components;
using _Project.Scripts.Runtime.Features.Physics.Moving.Requests;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class ApplyDashOnDashRequestSystem : IProtoInitSystem, IProtoFixedRunSystem
    {
        [DIRequests] private readonly MovingRequestsAspect _mrAspect;
        [DIRequests] private readonly RequestsAspect _rAspect;
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
            foreach (var reqE in _mrAspect.DashRequests)
            {
                if (!_rAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_mAspect.Dashables.Has(tarE)) continue;

                ref var dRequest = ref _mrAspect.DashRequestPool.Get(reqE);
                ref var dComponent = ref _mAspect.DashComponentPool.GetOrAdd(tarE);

                if (dComponent.AirQuantity >= dRequest.AirQuantity) continue;
                
                IncreaseAirQuantity(ref dComponent, tarE);
                CreateDashTimeout(dRequest, tarE);
                ApplyDash(dRequest, tarE);
            }
        }

        private void IncreaseAirQuantity(ref DashComponent dComponent, ProtoEntity tarE)
        {
            ref var gcResult = ref _mAspect.GroundCheckResultComponentPool.Get(tarE);
            if (!gcResult.Grounded) dComponent.AirQuantity++;
        }

        private void CreateDashTimeout(DashRequest dRequest, ProtoEntity tarE)
        {
            ref var dtComponent = ref _mAspect.DashTimeoutComponentPool.Add(tarE);
            dtComponent.CreationTime = _tService.UnscaledTime;
            dtComponent.Timeout = dRequest.TimeOut;
        }
        
        private void ApplyDash(DashRequest dRequest, ProtoEntity tarE)
        {
            ref var rbComponent = ref _psAspect.Rigidbody2DComponentPool.Get(tarE);
            ref var mComponent = ref _mAspect.MoveComponentPool.GetOrAdd(tarE);
            rbComponent.Rigidbody2D.ApplyDash(dRequest.Factor, MovingUtils.GetMoveXDirection(mComponent.Direction));
        }
    }
}