using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Shared.Systems
{
    public sealed class UpdateMoveSnapSystem : IProtoFixedRunSystem
    {
        [DI] private readonly MovingSharedAspect _msAspect;
        private readonly TimeService _tService;

        public UpdateMoveSnapSystem(TimeService tService)
        {
            _tService = tService;
        }

        public void FixedRun()
        {
            foreach (var e in _msAspect.MoveSnaps)
            {
                ref var msComponent = ref _msAspect.MoveSnapComponentPool.Get(e);
                var direction = msComponent.Host.position - msComponent.LastHostPos;
                msComponent.HostVelocity = direction / _tService.UnscaledFixedDeltaTime;
                msComponent.LastHostPos = msComponent.Host.position;
            }
        }
    }
}