using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
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
        
        public static ProtoEntity CreateEnableRequest(DomainAspect domainAspect)
        {
            var entity = domainAspect.RequestsAspect.CreateRequest();
            domainAspect.InputAspect.EnablePlatformsInputRequestPool.Add(entity);
            return entity;
        }
        
        public static ProtoEntity CreateDisableRequest(DomainAspect domainAspect)
        {
            var entity = domainAspect.RequestsAspect.CreateRequest();
            domainAspect.InputAspect.DisablePlatformsInputRequestPool.Add(entity);
            return entity;
        }
    }
}