using _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Systems
{
    public sealed class CamerasSwitchServiceOnRunObserverSystem : IProtoRunSystem
    {
        private readonly CamerasSwitchService _csService;
        private readonly CameraBrain _cBrain;

        public CamerasSwitchServiceOnRunObserverSystem(CamerasSwitchService csService, CameraBrain cBrain)
        {
            _csService = csService;
            _cBrain = cBrain;
        }

        public void Run()
        {
            var brain = _cBrain.Brain;

            if (!brain.IsBlending)
            {
                if (_csService.SwitchStarted) CompleteSwitching();
                return;
            }

            if (_csService.SwitchStarted) return;
            
            _csService.SwitchStarted = true;
        }

        private void CompleteSwitching()
        {
            _csService.SwitchGen++;
            _csService.SwitchStarted = false;
        }
    }
}