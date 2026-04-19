using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Extensions.Input;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class PlayerInputServiceUpdateSystem : IProtoRunSystem
    {
        private readonly PlayerInputService _service;
        private readonly PlayerInputConfig _config;

        public PlayerInputServiceUpdateSystem(PlayerInputService service, PlayerInputConfig config)
        {
            _service = service;
            _config = config;
        }

        public void Run()
        {
            if (_service.TryResetOnDisabled()) return;
            
            _service.SetWalkFieldsByVector2(_config.Walk.ReadValue<Vector2>());
            _service.JumpTriggered = _config.Jump.triggered;
            _service.DashTriggered = _config.Dash.triggered;
        }
    }
}