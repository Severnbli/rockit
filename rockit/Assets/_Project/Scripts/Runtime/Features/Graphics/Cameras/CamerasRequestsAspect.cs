using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras
{
    public sealed class CamerasRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<SwitchCameraRequest> SwitchCameraRequestsPool;
        public readonly ProtoIt SwitchCameraRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, SwitchCameraRequest>());
        
        public readonly ProtoPool<SetCameraBoundingColliderRequest> SetCameraBoundingColliderRequestsPool;
        public readonly ProtoIt SetCameraBoundingColliderRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, SetCameraBoundingColliderRequest>());
    }
}