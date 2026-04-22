using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Configs;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Systems
{
    public sealed class MoveRigidbodyPlatformByPlatformPositionChangeSystem : IProtoFixedRunSystem
    {
        [DI] private readonly PlatformsMovingAspect _pmAspect;
        [DI] private readonly PhysicsSharedAspect _psAspect;
        private readonly RigidbodyPlatformMovingConfig _rpmConfig;
        private readonly SharedPlatformMovingConfig _spmConfig;
        private readonly TimeService _tService;

        public MoveRigidbodyPlatformByPlatformPositionChangeSystem(RigidbodyPlatformMovingConfig rpmConfig, 
            SharedPlatformMovingConfig spmConfig, TimeService tService)
        {
            _rpmConfig = rpmConfig;
            _spmConfig = spmConfig;
            _tService = tService;
        }

        public void FixedRun()
        {
            foreach (var e in _pmAspect.PositionChangableRigidbodyPlatforms)
            {
                ref var ppcComponent = ref _pmAspect.PlatformPositionChangeComponentPool.Get(e);
                ref var rComponent = ref _psAspect.Rigidbody2DComponentPool.Get(e);

                if (!Vector2Utils.DistanceLessThanValue(ppcComponent.Target, rComponent.Rigidbody2D.position,
                        _spmConfig.PosTolerance))
                {
                    rComponent.Rigidbody2D.MoveTo(ppcComponent.Target, _rpmConfig.PosChangeSpeed,
                        _tService.UnscaledFixedTime);
                    continue;
                }
                
                rComponent.Rigidbody2D.MovePosition(ppcComponent.Target);
                _pmAspect.PlatformPositionChangeComponentPool.Del(e);
            }
        }
    }
}