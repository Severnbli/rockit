using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Systems
{
    public sealed class SwitchCameraOnSwitchCameraRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly CamerasRequestsAspect _crAspect;
        private readonly CamerasService _cService;
        private readonly CamerasConfig _cConfig;

        public SwitchCameraOnSwitchCameraRequestSystem(CamerasService cService, CamerasConfig cConfig)
        {
            _cService = cService;
            _cConfig = cConfig;
        }

        public void Run()
        {
            foreach (var e in _crAspect.SwitchCameraRequests)
            {
                ref var cwRequest = ref _crAspect.SwitchCameraRequestsPool.Get(e);
                if (cwRequest.Target == null) continue;

                if (_cService.LastCamera != null)
                {
                    _cService.LastCamera.Priority.Value = _cConfig.SecondaryCameraPriority;
                }

                cwRequest.Target.Priority.Enabled = true;
                cwRequest.Target.Priority.Value = _cConfig.PrimaryCameraPriority;
                _cService.LastCamera = cwRequest.Target;
                
                return;
            }
        }
    }
}