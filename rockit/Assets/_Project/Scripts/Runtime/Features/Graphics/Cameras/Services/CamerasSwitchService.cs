using System.Threading;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Services
{
    public sealed class CamerasSwitchService
    {
        public CancellationTokenSource SwitchCts = new ();
        public bool SwitchStarted = false;
    }
}