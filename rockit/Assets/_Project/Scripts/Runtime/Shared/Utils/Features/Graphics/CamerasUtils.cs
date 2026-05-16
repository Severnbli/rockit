using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
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
    }
}