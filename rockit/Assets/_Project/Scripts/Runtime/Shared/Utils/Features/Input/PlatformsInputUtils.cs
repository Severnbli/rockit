using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils.Features.Input
{
    public static class PlatformsInputUtils
    {
        public static void EnableInput(PlatformsInputService service, PlatformsInputConfig config)
        {
            service.Enabled = true;
            if (!service.Profile.PositionDisabled) config.Position.Enable();
            if (!service.Profile.RotationDisabled) config.Rotation.Enable();
            if (!service.Profile.ScaleDisabled) config.Scale.Enable();
        }

        public static void DisableInput(PlatformsInputService service, PlatformsInputConfig config)
        {
            service.Enabled = false;
            config.Position.Disable();
            config.Rotation.Disable();
            config.Scale.Disable();
        }
        
        public static ProtoEntity CreateEnableRequest(RequestsAspect aspect)
        {
            var entity = aspect.CreateRequest();
            aspect.InputRequestsAspect.EnablePlatformsInputRequestPool.Add(entity);
            return entity;
        }
        
        public static ProtoEntity CreateDisableRequest(RequestsAspect aspect)
        {
            var entity = aspect.CreateRequest();
            aspect.InputRequestsAspect.DisablePlatformsInputRequestPool.Add(entity);
            return entity;
        }
    }
}