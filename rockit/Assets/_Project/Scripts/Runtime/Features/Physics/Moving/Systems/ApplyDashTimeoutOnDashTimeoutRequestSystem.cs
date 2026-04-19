using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class ApplyDashTimeoutOnDashTimeoutRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly MovingRequestsAspect _mrAspect;
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DI] private readonly MovingAspect _mAspect;
        private ProtoWorld _world;
        private readonly TimeService _tService;

        public ApplyDashTimeoutOnDashTimeoutRequestSystem(TimeService tService)
        {
            _tService = tService;
        }
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var reqE in _mrAspect.DashTimeoutRequests)
            {
                if (!_crAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;

                ref var dtRequest = ref _mrAspect.DashTimeoutRequestPool.Get(reqE);
                ref var dtComponent = ref _mAspect.DashTimeoutComponentPool.GetOrAdd(tarE);

                dtComponent.CreationTime = _tService.UnscaledTime;
                dtComponent.Timeout = dtRequest.Timeout;
            }
        }
    }
}