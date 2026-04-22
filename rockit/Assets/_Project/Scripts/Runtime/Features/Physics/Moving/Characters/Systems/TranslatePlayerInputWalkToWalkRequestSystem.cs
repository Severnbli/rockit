using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Configs;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Requests;
using _Project.Scripts.Runtime.Shared.Utils;
using _Project.Scripts.Runtime.Shared.Utils.Moving;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class TranslatePlayerInputWalkToWalkRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly SharedAspect _sAspect;
        private ProtoWorld _world;
        private readonly PlayerInputService _piService;
        private readonly PlayerMovingConfig _pmConfig;

        public TranslatePlayerInputWalkToWalkRequestSystem(PlayerInputService piService, PlayerMovingConfig pmConfig)
        {
            _piService = piService;
            _pmConfig = pmConfig;
        }
        
        public void Init(IProtoSystems systems)
        {
            _world = _sAspect.World();
        }

        public void Run()
        {
            if (!_piService.WalkTriggered) return;

            var prepared = new WalkRequest
            {
                Factor = _piService.Walk * _pmConfig.WalkSpeed,
                Deceleration = _pmConfig.WalkDeceleration
            };
            
            foreach (var e in _sAspect.Players)
            {
                var packed = _world.PackEntityWithWorld(e);
                CharactersMovingUtils.CreateWalkRequest(_rAspect, packed, prepared);
            }
        }
    }
}