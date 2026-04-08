using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils.Input
{
    public static class PlayerInputUtils
    {
        public static void EnableInput(PlayerInputService service, PlayerInputConfig config)
        {
            service.Enabled = true;
            config.Walk.Enable();
            config.Jump.Enable();
            config.Dash.Enable();
        }

        public static void DisableInput(PlayerInputService service, PlayerInputConfig config)
        {
            service.Enabled = false;
            config.Walk.Disable();
            config.Jump.Disable();
            config.Dash.Disable();
        }
        
        public static ProtoEntity CreateEnableRequest(DomainAspect domainAspect)
        {
            var entity = domainAspect.RequestsAspect.CreateRequest();
            domainAspect.InputAspect.EnablePlayerInputRequestPool.Add(entity);
            return entity;
        }
        
        public static ProtoEntity CreateDisableRequest(DomainAspect domainAspect)
        {
            var entity = domainAspect.RequestsAspect.CreateRequest();
            domainAspect.InputAspect.DisablePlayerInputRequestPool.Add(entity);
            return entity;
        }
    }
}