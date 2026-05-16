using System.Threading;
using Unity.Cinemachine;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Services
{
    public class CamerasService
    {
        public CinemachineCamera LastCamera = null;
        public CancellationTokenSource ChangeCts = new ();
    }
}