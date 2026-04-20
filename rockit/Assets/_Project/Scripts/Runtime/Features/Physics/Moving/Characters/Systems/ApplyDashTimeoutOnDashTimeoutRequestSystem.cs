using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class ApplyDashTimeoutOnDashTimeoutRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly CharactersMovingRequestsAspect _cmrAspect;
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DI] private readonly CharactersMovingAspect _cmAspect;
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
            foreach (var reqE in _cmrAspect.DashTimeoutRequests)
            {
                if (!_crAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;

                ref var dtRequest = ref _cmrAspect.DashTimeoutRequestPool.Get(reqE);
                ref var dtComponent = ref _cmAspect.DashTimeoutComponentPool.GetOrAdd(tarE);

                dtComponent.CreationTime = _tService.UnscaledTime;
                dtComponent.Timeout = dtRequest.Timeout;
            }
        }
    }
}