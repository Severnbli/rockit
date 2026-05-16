using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Systems
{
    public sealed class CamerasSwitchServiceOnRunObserverSystem : IProtoRunSystem
    {
        private readonly CamerasSwitchService _csService;
        private readonly CamerasService _cService;
        private readonly CameraBrain _cBrain;
        private readonly TimeService _tService;

        public CamerasSwitchServiceOnRunObserverSystem(CamerasSwitchService csService, CamerasService cService, 
            CameraBrain cBrain, TimeService tService)
        {
            _csService = csService;
            _cService = cService;
            _cBrain = cBrain;
            _tService = tService;
        }

        public void Run()
        {
            var brain = _cBrain.Brain;
            
            if (!brain.IsBlending)
            {
                if (_csService.SwitchStarted) _csService.Reset();
                return;
            }

            if (!_csService.SwitchStarted)
            {
                _csService.EscortCamera = _cService.LastCamera;
                _csService.SwitchStartTime = _tService.UnscaledTime;
                _csService.SwitchDuration = brain.ActiveBlend.Duration + CamerasContracts.BrainBlendDurationLag;
                _csService.SwitchStarted = true;
                return;
            }

            if (_tService.Expired(_csService.SwitchStartTime, _csService.SwitchDuration) 
                || _csService.EscortCamera != _cService.LastCamera)
            {
                _csService.Reset();
            }
        }
    }
}