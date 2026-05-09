using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Systems
{
    public sealed class UpdateRunBoolByCharacterVelocityOnFixedRunSystem : IProtoFixedRunSystem
    {
        [DI] private readonly AnimationsSharedAspect _asAspect;
        [DI] private readonly CharactersMovingAspect _cmAspect;
        private readonly CharacterAnimationConfig _caConfig;

        public UpdateRunBoolByCharacterVelocityOnFixedRunSystem(CharacterAnimationConfig caConfig)
        {
            _caConfig = caConfig;
        }

        public void FixedRun()
        {
            foreach (var e in _asAspect.CharacterAnimators)
            {
                if (!_cmAspect.CharacterVelocities.Has(e)) continue;
                
                ref var aComponent = ref _asAspect.AnimatorComponentPool.Get(e);
                ref var cvComponent = ref _cmAspect.CharacterVelocityComponentPool.Get(e);
                
                aComponent.Animator.SetBool(_caConfig.RunBool, 
                    !Mathf.Approximately(cvComponent.Velocity.x, PhysicsSharedContracts.ForceNotApplied));
            }
        }
    }
}