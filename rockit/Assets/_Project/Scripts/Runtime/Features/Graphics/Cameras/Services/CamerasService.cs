using System.Threading;
using Unity.Cinemachine;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Services
{
    public sealed class CamerasService
    {
        public CinemachineCamera LastCamera = null;
        public CancellationTokenSource SwitchCts = new ();
        public bool SwitchStarted = false; 
    }
}