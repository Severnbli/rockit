using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Configs;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Systems
{
    public sealed class RotateRigidbodyPlatformByPlatformRotationChangeSystem : IProtoFixedRunSystem
    {
        [DI] private readonly PlatformsMovingAspect _pmAspect;
        [DI] private readonly PhysicsSharedAspect _psAspect;
        [DI] private readonly SharedAspect _sAspect;
        private readonly RigidbodyPlatformMovingConfig _rpmConfig;
        private readonly SharedPlatformMovingConfig _spmConfig;
        private readonly TimeService _tService;

        public RotateRigidbodyPlatformByPlatformRotationChangeSystem(RigidbodyPlatformMovingConfig rpmConfig,
            SharedPlatformMovingConfig spmConfig, TimeService tService)
        {
            _rpmConfig = rpmConfig;
            _spmConfig = spmConfig;
            _tService = tService;
        }

        public void FixedRun()
        {
            foreach (var e in _pmAspect.RotationChangableRigidbodyPlatforms)
            {
                ref var prcComponent = ref _pmAspect.PlatformRotationChangeComponentPool.Get(e);
                ref var rComponent = ref _psAspect.Rigidbody2DComponentPool.Get(e);
                ref var tComponent = ref _sAspect.TransformComponentPool.Get(e);

                if (!QuaternionUtils.AngleLessThanValue(prcComponent.Target, tComponent.Transform.rotation,
                        _spmConfig.RotTolerance))
                {
                    rComponent.Rigidbody2D.RotateTo(prcComponent.Target, _rpmConfig.RotChangeSpeed,
                        _tService.UnscaledFixedDeltaTime);
                    continue;
                }
                
                rComponent.Rigidbody2D.MoveRotation(prcComponent.Target);
                _pmAspect.PlatformRotationChangeComponentPool.Del(e);
            }
        }
    }
}