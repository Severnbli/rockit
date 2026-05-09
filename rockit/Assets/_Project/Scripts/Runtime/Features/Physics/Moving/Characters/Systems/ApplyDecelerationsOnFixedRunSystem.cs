using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class ApplyDecelerationsOnFixedRunSystem : IProtoFixedRunSystem
    {
        [DI] private readonly CharactersMovingAspect _cmAspect;
        [DI] private readonly PhysicsSharedAspect _psAspect;
        private readonly TimeService _tService;

        public ApplyDecelerationsOnFixedRunSystem(TimeService tService)
        {
            _tService = tService;
        }

        public void FixedRun()
        {
            foreach (var e in _cmAspect.Deceleratables)
            {
                ref var cmComponent = ref _cmAspect.CharacterMoveComponentPool.Get(e);
                ref var cvComponent = ref _cmAspect.CharacterVelocityComponentPool.Get(e);
                
                var velocity = cvComponent.Velocity;
                
                velocity.x = Mathf.MoveTowards(
                    velocity.x,
                    0f,
                    cmComponent.WalkDeceleration * _tService.UnscaledFixedDeltaTime
                );
                
                if (velocity.y <= 0f) return;

                velocity.y = Mathf.MoveTowards(
                    velocity.x,
                    0f,
                    cmComponent.JumpDeceleration * _tService.UnscaledFixedDeltaTime
                );
            }
        }
    }
}