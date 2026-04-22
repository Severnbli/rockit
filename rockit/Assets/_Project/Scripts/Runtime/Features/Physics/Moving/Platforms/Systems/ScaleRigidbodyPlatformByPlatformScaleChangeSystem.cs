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
    public class ScaleRigidbodyPlatformByPlatformScaleChangeSystem : IProtoFixedRunSystem
    {
        [DI] private readonly PlatformsMovingAspect _pmAspect;
        [DI] private readonly PhysicsSharedAspect _psAspect;
        [DI] private readonly SharedAspect _sAspect;
        private readonly RigidbodyPlatformMovingConfig _rpmConfig;
        private readonly SharedPlatformMovingConfig _spmConfig;
        private readonly TimeService _tService;

        public ScaleRigidbodyPlatformByPlatformScaleChangeSystem(RigidbodyPlatformMovingConfig rpmConfig,
            SharedPlatformMovingConfig spmConfig, TimeService tService)
        {
            _rpmConfig = rpmConfig;
            _spmConfig = spmConfig;
            _tService = tService;
        }

        public void FixedRun()
        {
            foreach (var e in _pmAspect.ScaleChangableRigidbodyPlatforms)
            {
                ref var pscComponent = ref _pmAspect.PlatformScaleChangeComponentPool.Get(e);
                ref var tComponent = ref _sAspect.TransformComponentPool.Get(e);

                if (!Vector2Utils.DistanceLessThanValue(pscComponent.Target, tComponent.Transform.localScale,
                        _spmConfig.ScaleTolerance))
                {
                    tComponent.Transform.ScaleTo(pscComponent.Target, _rpmConfig.ScaleChangeSpeed,
                        _tService.UnscaledFixedDeltaTime);
                    continue;
                }

                tComponent.Transform.localScale = pscComponent.Target;
                _pmAspect.PlatformScaleChangeComponentPool.Del(e);
            }
        }
    }
}