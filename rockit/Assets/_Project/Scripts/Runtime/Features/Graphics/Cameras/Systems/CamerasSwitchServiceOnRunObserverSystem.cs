using System.Threading;
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
            switch (_cBrain.Brain.IsBlending, _csService.SwitchStarted)
            {
                case (false, false):
                case (true, true):
                {
                    return;
                }
                case (true, false):
                {
                    _csService.SwitchStarted = true;
                    return;
                }
            }

            _csService.SwitchCts?.Cancel();
            _csService.SwitchCts?.Dispose();
            _csService.SwitchCts = new CancellationTokenSource();
        }
    }
}