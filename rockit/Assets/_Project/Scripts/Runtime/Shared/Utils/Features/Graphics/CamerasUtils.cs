using System;
using System.Threading;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Graphics.Cameras;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Requests;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Cysharp.Threading.Tasks;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils.Features.Graphics
{
    public static class CamerasUtils
    {
        public static ProtoEntity CreateSwitchCameraRequest(RequestsAspect aspect, SwitchCameraRequest prepared)
        {
            return aspect.CreateRequest(aspect.GraphicsSharedRequestsAspect.CamerasRequestsAspect.SwitchCameraRequestsPool, 
                prepared: prepared);
        }

        public static async UniTask AwaitCamerasSwitching(CamerasSwitchService csService, CancellationToken ct = default)
        {
            using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(ct, csService.SwitchCts.Token);
            
            await UniTask.Delay(TimeSpan.FromSeconds(CamerasContracts.MaxBrainBlendDuration), 
                cancellationToken: linkedCts.Token);
        }
    }
}