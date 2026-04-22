using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Shared.Systems
{
    public sealed class ApplySnapByMoveSnapSystem : IProtoFixedRunSystem
    {
        [DI] private readonly MovingSharedAspect _msAspect;
        private readonly TimeService _tService;

        public ApplySnapByMoveSnapSystem(TimeService tService)
        {
            _tService = tService;
        }

        public void FixedRun()
        {
            foreach (var e in _msAspect.MoveSnaps)
            {
                ref var msComponent = ref _msAspect.MoveSnapComponentPool.Get(e);
                var velocity = (msComponent.Host.position - msComponent.LastHostPos) / _tService.UnscaledFixedDeltaTime;
                msComponent.LastHostPos = msComponent.Host.position;

                msComponent.Tied.linearVelocity += velocity;
            }
        }
    }
}