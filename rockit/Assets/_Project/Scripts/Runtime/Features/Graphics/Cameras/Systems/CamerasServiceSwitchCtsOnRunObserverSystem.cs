using System.Threading;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Systems
{
    public sealed class CamerasServiceSwitchCtsOnRunObserverSystem : IProtoRunSystem
    {
        private readonly CamerasService _cService;
        private readonly CameraBrain _cBrain;

        public CamerasServiceSwitchCtsOnRunObserverSystem(CamerasService cService, CameraBrain cBrain)
        {
            _cService = cService;
            _cBrain = cBrain;
        }

        public void Run()
        {
            switch (_cBrain.Brain.IsBlending, _cService.SwitchStarted)
            {
                case (false, false):
                case (true, true):
                {
                    return;
                }
                case (true, false):
                {
                    _cService.SwitchStarted = true;
                    return;
                }
            }

            _cService.SwitchCts?.Cancel();
            _cService.SwitchCts?.Dispose();
            _cService.SwitchCts = new CancellationTokenSource();
        }
    }
}