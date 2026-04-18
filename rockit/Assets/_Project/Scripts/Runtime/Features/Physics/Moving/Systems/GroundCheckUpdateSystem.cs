using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Physics.Moving.Configs;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class GroundCheckUpdateSystem : IProtoRunSystem
    {
        [DI] private readonly MovingAspect _movingAspect;
        [DI] private readonly SharedAspect _sharedAspect;
        private readonly SharedMovingConfig _sharedMovingConfig;
        private readonly TimeService _timeService;
        private readonly LayersConfig _layersConfig;

        public GroundCheckUpdateSystem(SharedMovingConfig sharedMovingConfig, TimeService timeService, LayersConfig layersConfig)
        {
            _sharedMovingConfig = sharedMovingConfig;
            _timeService = timeService;
            _layersConfig = layersConfig;
        }

        public void Run()
        {
            foreach (var e in _movingAspect.GroundCheckable)
            {
                ref var groundCheck = ref _movingAspect.GroundCheckComponentPool.Get(e);
                ref var transform = ref _sharedAspect.TransformComponentPool.Get(e);
                ref var result = ref _movingAspect.GroundCheckResultComponentPool.GetOrAdd(e);

                var grounded = MovingUtils.Grounded(transform.Transform.position, groundCheck, _layersConfig,
                    out var groundCollider);

                result.Grounded = true;
                
                if (grounded)
                {
                    result.GroundCollider = groundCollider;
                    result.LastGroundedTiming = _timeService.UnscaledTime;
                    return;
                }

                if (MovingUtils.CoyoteTimeExpired(result, _timeService, _sharedMovingConfig))
                {
                    result.Grounded = false;
                }
            }
        }
    }
}