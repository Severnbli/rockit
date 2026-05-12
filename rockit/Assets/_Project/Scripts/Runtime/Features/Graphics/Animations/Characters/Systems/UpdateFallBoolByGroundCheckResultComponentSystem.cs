using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Systems
{
    public sealed class UpdateFallBoolByGroundCheckResultComponentSystem : IProtoRunSystem
    {
        [DI] private readonly AnimationsSharedAspect _asAspect;
        [DI] private readonly CharactersMovingAspect _cmAspect;
        private readonly CharacterAnimationConfig _caConfig;
        private readonly TimeService _tService;

        public UpdateFallBoolByGroundCheckResultComponentSystem(CharacterAnimationConfig caConfig, TimeService tService)
        {
            _caConfig = caConfig;
            _tService = tService;
        }

        public void Run()
        {
            foreach (var e in _asAspect.CharacterAnimators)
            {
                if (!_cmAspect.GroundCheckResults.Has(e)) return;
                
                ref var aComponent = ref _asAspect.AnimatorComponentPool.Get(e);
                ref var gcrComponent = ref _cmAspect.GroundCheckResultComponentPool.Get(e);

                var fall = !gcrComponent.Grounded;

                if (fall && _tService.UnscaledTime < gcrComponent.LastGroundedTiming + _caConfig.FallTolerance)
                {
                    fall = false;
                }
                
                aComponent.Animator.SetBool(_caConfig.FallBool, fall);
            }
        }
    }
}