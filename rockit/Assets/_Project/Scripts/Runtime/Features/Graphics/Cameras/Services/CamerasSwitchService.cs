using System.Threading;
using Unity.Cinemachine;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Services
{
    public sealed class CamerasSwitchService
    {
        public bool SwitchStarted = false;
        public CinemachineCamera EscortCamera = null;
        public CancellationTokenSource SwitchCts = new ();
        public float SwitchStartTime;
        public float SwitchDuration;
    }
}