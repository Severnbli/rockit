using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class ApplyJumpDecelerationOnFixedRunSystem : IProtoFixedRunSystem
    {
        [DI] private readonly CharactersMovingAspect _cmAspect;
        private readonly TimeService _tService;

        public ApplyJumpDecelerationOnFixedRunSystem(TimeService tService)
        {
            _tService = tService;
        }

        public void FixedRun()
        {
            foreach (var e in _cmAspect.JumpDeceleratables)
            {
                ref var cmComponent = ref _cmAspect.CharacterMoveComponentPool.Get(e);
                ref var cvComponent = ref _cmAspect.CharacterVelocityComponentPool.Get(e);
                
                var velocity = cvComponent.Velocity;
                
                velocity.y = Mathf.MoveTowards(
                    velocity.x,
                    -cmComponent.MaxFallingVelocity,
                    cmComponent.JumpDeceleration * _tService.UnscaledFixedDeltaTime
                );
                
                cvComponent.Velocity = velocity;
            }
        }
    }
}