using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Shared;
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
                ref var cvComponent = ref _cmAspect.CharacterVelocityComponentPool.GetOrAdd(e);
                ref var gcrComponent = ref _cmAspect.GroundCheckResultComponentPool.GetOrAdd(e);

                var velocity = cvComponent.Velocity;
                
                if (gcrComponent.Grounded && velocity.y <= 0)
                {
                    velocity.y = PhysicsSharedContracts.ForceNotApplied;
                }
                else
                {
                    velocity.y = Mathf.MoveTowards(
                        velocity.y,
                        -cmComponent.MaxFallingVelocity,
                        cmComponent.JumpDeceleration * _tService.UnscaledFixedDeltaTime
                    );
                }
                
                cvComponent.Velocity = velocity;
            }
        }
    }
}