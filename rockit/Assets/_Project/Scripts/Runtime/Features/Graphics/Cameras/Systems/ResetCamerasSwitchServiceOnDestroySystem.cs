using _Project.Scripts.Runtime.Features.Graphics.Cameras.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Systems
{
    public sealed class ResetCamerasSwitchServiceOnDestroySystem : IProtoDestroySystem
    {
        private readonly CamerasSwitchService _csService;

        public ResetCamerasSwitchServiceOnDestroySystem(CamerasSwitchService csService)
        {
            _csService = csService;
        }

        public void Destroy()
        {
            _csService.Reset();
        }
    }
}