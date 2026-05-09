using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class ApplyWalkDecelerationOnFixedRunSystem : IProtoFixedRunSystem
    {
        [DI] private readonly CharactersMovingAspect _cmAspect;
        private readonly TimeService _tService;

        public ApplyWalkDecelerationOnFixedRunSystem(TimeService tService)
        {
            _tService = tService;
        }

        public void FixedRun()
        {
            foreach (var e in _cmAspect.WalkDeceleratables)
            {
                ref var cmComponent = ref _cmAspect.CharacterMoveComponentPool.Get(e);
                ref var cvComponent = ref _cmAspect.CharacterVelocityComponentPool.Get(e);
                
                var velocity = cvComponent.Velocity;
                
                velocity.x = Mathf.MoveTowards(
                    velocity.x,
                    0f,
                    cmComponent.WalkDeceleration * _tService.UnscaledFixedDeltaTime
                );
                
                cvComponent.Velocity = velocity;
            }
        }
    }
}