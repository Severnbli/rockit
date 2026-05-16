using System;
using System.Threading;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Services;
using _Project.Scripts.Runtime.Shared.Utils.Features.Graphics;
using _Project.Scripts.Runtime.Shared.Utils.Shared;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Types
{
    public class CameraSwitchAwaiter : ICameraSwitchAwaiter
    {
        protected readonly CamerasSwitchService CsService;
        protected readonly CameraBrain CBrain;

        public CameraSwitchAwaiter(CamerasSwitchService csService, CameraBrain cBrain)
        {
            CsService = csService;
            CBrain = cBrain;
        }

        public async UniTask AwaitSwitch(CancellationToken ct = default)
        {
            if (!CBrain.Brain.IsBlending)
            {
                await AwaitStartBlending(ct);
                if (!CBrain.Brain.IsBlending) return;
            }
            
            await CamerasUtils.AwaitCamerasSwitching(CsService, ct);
        }

        private async UniTask AwaitStartBlending(CancellationToken ct = default)
        {
            var brainTask = UniTask.WaitUntil(CBrain.Brain, brain => !brain.IsBlending, cancellationToken: ct);
            await UniTaskUtils.WaitWithTimeout(brainTask, TimeSpan.FromSeconds(CamerasContracts.BrainBlendStartLag), ct);
        }
    }
}