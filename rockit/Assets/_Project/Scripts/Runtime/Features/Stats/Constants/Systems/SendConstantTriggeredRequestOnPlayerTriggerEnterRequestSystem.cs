using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services;
using _Project.Scripts.Runtime.Features.Player;
using _Project.Scripts.Runtime.Features.Stats.Constants.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Features.Stats;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Systems
{
    public sealed class SendConstantTriggeredRequestOnPlayerTriggerEnterRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly PlayerRequestsAspect _prAspect;
        [DI] private readonly ConstantsAspect _cAspect;
        private readonly SharedIndexService _siService;
        private ProtoWorld _world;

        public SendConstantTriggeredRequestOnPlayerTriggerEnterRequestSystem(SharedIndexService siService)
        {
            _siService = siService;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            var goIndex = _siService.GameObjectIndex;
            
            foreach (var reqE in _prAspect.PlayerEnterTriggerRequests)
            {
                ref var petRequest = ref _prAspect.PlayerEnterTriggerRequestPool.Get(reqE);
                if (!goIndex.TryGetEntityFromIndex(petRequest.Collider.gameObject, _world, out var tarE)) continue;
                if (!_cAspect.Constants.Has(tarE)) continue;

                ref var cComponent = ref _cAspect.ConstantComponentPool.Get(tarE);

                var prepared = new ConstantTriggeredRequest
                {
                    ConstantId = cComponent.Id
                };
                var packed = _world.PackEntityWithWorld(tarE);

                ConstantsUtils.CreateConstantTriggeredRequests(_rAspect, packed, prepared);
            }
        }
    }
}