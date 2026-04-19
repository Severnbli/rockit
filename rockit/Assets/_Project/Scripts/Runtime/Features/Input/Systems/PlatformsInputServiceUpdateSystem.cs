using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Extensions.Input;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class PlatformsInputServiceUpdateSystem : IProtoRunSystem
    {
        private readonly PlatformsInputService _service;
        private readonly PlatformsInputConfig _config;

        public PlatformsInputServiceUpdateSystem(PlatformsInputService service, PlatformsInputConfig config)
        {
            _service = service;
            _config = config;
        }

        public void Run()
        {
            if (_service.TryResetOnDisabled()) return;

            _service.PositionTriggered = _config.Position.triggered;
            _service.RotationTriggered = _config.Rotation.triggered;
            _service.ScaleTriggered = _config.Scale.triggered;
        }
    }
}