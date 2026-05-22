using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services;
using _Project.Scripts.Runtime.Features.Player;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Features.World;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.World.Teleporters.Systems
{
    public sealed class SendTeleporterTriggeredRequestOnPlayerTriggerEnterRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly PlayerRequestsAspect _prAspect;
        [DI] private readonly TeleportersAspect _tAspect;
        private readonly SharedIndexService _siService;
        private ProtoWorld _world;

        public SendTeleporterTriggeredRequestOnPlayerTriggerEnterRequestSystem(SharedIndexService siService)
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
                if (!_tAspect.Teleportes.Has(tarE)) continue;

                var packed = _world.PackEntityWithWorld(tarE);
                TeleportersUtils.CreateTeleporterTriggeredRequest(_rAspect, packed);
            }
        }
    }
}