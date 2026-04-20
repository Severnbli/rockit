using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Moving.Shared;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class ApplyWalkDecelerationOnFixedRunSystem : IProtoFixedRunSystem
    {
        [DI] private readonly CharactersMovingAspect _cmAspect;
        [DI] private readonly MovingSharedAspect _msAspect;
        [DI] private readonly PhysicsSharedAspect _psAspect;
        private readonly TimeService _tService;

        public ApplyWalkDecelerationOnFixedRunSystem(TimeService tService)
        {
            _tService = tService;
        }

        public void FixedRun()
        {
            foreach (var e in _cmAspect.Deceleratables)
            {
                ref var mComponent = ref _msAspect.MoveComponentPool.Get(e);
                ref var rComponent = ref _psAspect.Rigidbody2DComponentPool.Get(e);
                rComponent.Rigidbody2D.ApplyWalkDeceleration(mComponent.WalkDeceleration,
                    _tService.UnscaledFixedDeltaTime);
            }
        }
    }
}