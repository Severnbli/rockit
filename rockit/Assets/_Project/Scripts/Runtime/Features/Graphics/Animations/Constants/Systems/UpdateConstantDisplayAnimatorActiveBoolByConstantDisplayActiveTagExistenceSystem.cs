using _Project.Scripts.Runtime.Features.Graphics.Animations.Constants.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared;
using _Project.Scripts.Runtime.Features.Stats.Constants;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Constants.Systems
{
    public sealed class UpdateConstantDisplayAnimatorActiveBoolByConstantDisplayActiveTagExistenceSystem : IProtoRunSystem
    {
        [DI] private readonly AnimationsSharedAspect _asAspect;
        [DI] private readonly ConstantsAspect _cAspect;
        private readonly ConstantsDisplaysAnimationsConfig _cdaConfig;

        public UpdateConstantDisplayAnimatorActiveBoolByConstantDisplayActiveTagExistenceSystem(ConstantsDisplaysAnimationsConfig cdaConfig)
        {
            _cdaConfig = cdaConfig;
        }

        public void Run()
        {
            foreach (var e in _asAspect.ConstantDisplayAnimators)
            {
                ref var aComponent = ref _asAspect.AnimatorComponentPool.Get(e);
                var existence = _cAspect.ConstantActiveDisplays.Has(e);
                aComponent.Animator.SetBool(_cdaConfig.ActiveBool, existence);
            }
        }
    }
}