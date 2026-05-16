using System.Threading;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Services;

namespace _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics
{
    public static class CamerasExtensions
    {
        public static void Reset(this CamerasSwitchService csService)
        {
            csService.SwitchCts?.Cancel();
            csService.SwitchCts?.Dispose();
            csService.SwitchCts = new CancellationTokenSource();
            csService.SwitchStarted = false;
        }
    }
}