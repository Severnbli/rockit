using _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared;
using _Project.Scripts.Runtime.Features.Physics.Moving;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Systems
{
    public sealed class UpdateDashedBoolOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly AnimationsSharedAspect _asAspect;
        [DI] private readonly MovingAspect _mAspect;
        private readonly CharacterAnimationConfig _caConfig;

        public UpdateDashedBoolOnRunSystem(CharacterAnimationConfig caConfig)
        {
            _caConfig = caConfig;
        }

        public void Run()
        {
            foreach (var e in _asAspect.CharacterAnimators)
            {
                ref var aComponent = ref _asAspect.AnimatorComponentPool.Get(e);
                var dashed = _mAspect.DashTimeouts.Has(e);
                
                aComponent.Animator.SetBool(_caConfig.DashedBool, dashed);
            }
        }
    }
}