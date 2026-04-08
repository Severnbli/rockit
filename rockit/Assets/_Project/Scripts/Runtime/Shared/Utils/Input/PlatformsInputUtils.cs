using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils.Input
{
    public static class PlatformsInputUtils
    {
        public static void EnableInput(PlatformsInputService service, PlatformsInputConfig config)
        {
            service.Enabled = true;
            config.Position.Enable();
            config.Rotation.Enable();
            config.Scale.Enable();
        }

        public static void DisableInput(PlatformsInputService service, PlatformsInputConfig config)
        {
            service.Enabled = false;
            config.Position.Disable();
            config.Rotation.Disable();
            config.Scale.Disable();
        }
        
        public static ProtoEntity CreateEnableRequest(RequestsWorldAspect aspect)
        {
            var entity = aspect.RequestsAspect.CreateRequest();
            aspect.InputAspect.EnablePlatformsInputRequestPool.Add(entity);
            return entity;
        }
        
        public static ProtoEntity CreateDisableRequest(RequestsWorldAspect aspect)
        {
            var entity = aspect.RequestsAspect.CreateRequest();
            aspect.InputAspect.DisablePlatformsInputRequestPool.Add(entity);
            return entity;
        }
    }
}