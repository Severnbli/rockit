using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Configs;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Requests;
using _Project.Scripts.Runtime.Features.Stats.Player.Services;
using _Project.Scripts.Runtime.Shared.Utils.Features.Physics.Moving;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class TranslatePlayerInputJumpToJumpRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly SharedAspect _sAspect;
        private ProtoWorld _world;
        private readonly PlayerInputService _piService;
        private readonly PlayerMovingConfig _pmConfig;
        private readonly PlayerStatsService _psService;

        public TranslatePlayerInputJumpToJumpRequestSystem(PlayerInputService piService, PlayerMovingConfig pmConfig,
            PlayerStatsService psService)
        {
            _piService = piService;
            _pmConfig = pmConfig;
            _psService = psService;
        }
        
        public void Init(IProtoSystems systems)
        {
            _world = _sAspect.World();
        }

        public void Run()
        {
            if (!_piService.JumpTriggered) return;

            var prepared = new JumpRequest
            {
                Factor = _pmConfig.JumpPower * _psService.JumpFactorModifier,
                Deceleration = _pmConfig.JumpDeceleration
            };

            foreach (var e in _sAspect.Players)
            {
                var packed = _world.PackEntityWithWorld(e);
                CharactersMovingUtils.CreateJumpRequest(_rAspect, packed, prepared);
            }
        }
    }
}