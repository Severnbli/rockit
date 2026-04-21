using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Configs;
using _Project.Scripts.Runtime.Shared.Utils;
using _Project.Scripts.Runtime.Shared.Utils.Moving;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class GroundCheckUpdateSystem : IProtoRunSystem
    {
        [DI] private readonly CharactersMovingAspect _cmAspect;
        [DI] private readonly SharedAspect _sAspect;
        private readonly SharedCharacterMovingConfig _scmConfig;
        private readonly TimeService _tService;
        private readonly LayersConfig _lConfig;

        public GroundCheckUpdateSystem(SharedCharacterMovingConfig scmConfig, TimeService tService, LayersConfig lConfig)
        {
            _scmConfig = scmConfig;
            _tService = tService;
            _lConfig = lConfig;
        }

        public void Run()
        {
            foreach (var e in _cmAspect.GroundCheckable)
            {
                ref var groundCheck = ref _cmAspect.GroundCheckComponentPool.Get(e);
                ref var transform = ref _sAspect.TransformComponentPool.Get(e);
                ref var result = ref _cmAspect.GroundCheckResultComponentPool.GetOrAdd(e);

                var grounded = CharactersMovingUtils.Grounded(transform.Transform.position, groundCheck, _lConfig,
                    out var groundCollider);

                result.Grounded = true;
                
                if (grounded)
                {
                    result.GroundCollider = groundCollider;
                    result.LastGroundedTiming = _tService.UnscaledTime;
                    return;
                }

                if (CharactersMovingUtils.CoyoteTimeExpired(result, _tService, _scmConfig))
                {
                    result.Grounded = false;
                }
            }
        }
    }
}