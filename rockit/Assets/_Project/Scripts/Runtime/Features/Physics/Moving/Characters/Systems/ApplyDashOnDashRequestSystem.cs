using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Components;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Requests;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Features.Physics.Moving;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class ApplyDashOnDashRequestSystem : IProtoInitSystem, IProtoFixedRunSystem
    {
        [DIRequests] private readonly CharactersMovingRequestsAspect _cmrAspect;
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly CharactersMovingAspect _cmAspect;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }
        
        public void FixedRun()
        {
            foreach (var reqE in _cmrAspect.DashRequests)
            {
                if (!_rAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_cmAspect.Dashables.Has(tarE)) continue;

                ref var dRequest = ref _cmrAspect.DashRequestPool.Get(reqE);
                ref var dComponent = ref _cmAspect.DashComponentPool.GetOrAdd(tarE);

                if (dComponent.AirQuantity >= dRequest.AirQuantity) continue;
                
                IncreaseAirQuantity(ref dComponent, tarE);
                CreateDashTimeoutRequest(dRequest, tarE);
                CreateDashAppliedRequests(tarE);
                
                ref var cmComponent = ref _cmAspect.CharacterMoveComponentPool.GetOrAdd(tarE);
                ref var cvComponent = ref _cmAspect.CharacterVelocityComponentPool.GetOrAdd(tarE);
            
                cvComponent.Velocity.x = dRequest.Factor * CharactersMovingUtils.GetMoveXDirection(cmComponent.Direction);
                cvComponent.Velocity.y = PhysicsSharedContracts.ForceNotApplied;
            }
        }

        private void IncreaseAirQuantity(ref DashComponent dComponent, ProtoEntity tarE)
        {
            ref var gcResult = ref _cmAspect.GroundCheckResultComponentPool.Get(tarE);
            if (!gcResult.Grounded) dComponent.AirQuantity++;
        }

        private void CreateDashTimeoutRequest(DashRequest dRequest, ProtoEntity tarE)
        {
            var prepared = new DashTimeoutRequest
            {
                Timeout = dRequest.TimeOut
            };
            var packed = _world.PackEntityWithWorld(tarE);

            CharactersMovingUtils.CreateDashTimeoutRequest(_rAspect, packed, prepared);
        }
        
        private void CreateDashAppliedRequests(ProtoEntity tarE)
        {
            CharactersMovingUtils.CreateDashAppliedRequest(_rAspect, false, _world.PackEntityWithWorld(tarE));
            CharactersMovingUtils.CreateDashAppliedRequest(_rAspect, true, _world.PackEntityWithWorld(tarE));
        }
    }
}