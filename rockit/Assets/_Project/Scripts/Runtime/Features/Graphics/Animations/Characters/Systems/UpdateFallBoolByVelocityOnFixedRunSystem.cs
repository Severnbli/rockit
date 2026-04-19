using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Systems
{
    public sealed class UpdateFallBoolByVelocityOnFixedRunSystem : IProtoFixedRunSystem
    {
        [DI] private AnimationsSharedAspect _asAspect;
        [DI] private PhysicsSharedAspect _psAspect;
        private readonly CharacterAnimationConfig _caConfig;

        public UpdateFallBoolByVelocityOnFixedRunSystem(CharacterAnimationConfig caConfig)
        {
            _caConfig = caConfig;
        }

        public void FixedRun()
        {
            foreach (var e in _asAspect.CharacterAnimators)
            {
                if (!_psAspect.Rigidbodies2D.Has(e)) continue;
                
                ref var aComponent = ref _asAspect.AnimatorComponentPool.Get(e);
                ref var rComponent = ref _psAspect.Rigidbody2DComponentPool.Get(e);
                
                aComponent.Animator.SetBool(_caConfig.FallBool, rComponent.Rigidbody2D.Falling());
            }
        }
    }
}