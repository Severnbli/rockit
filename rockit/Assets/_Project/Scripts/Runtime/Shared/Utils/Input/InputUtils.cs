using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils.Input
{
    public static class InputUtils
    {
        public static ProtoEntity CreateEnablePlayerInputRequest(DomainAspect domainAspect)
        {
            var entity = domainAspect.RequestsAspect.CreateRequest();
            domainAspect.InputAspect.EnablePlayerInputRequestPool.Add(entity);
            return entity;
        }
        
        public static ProtoEntity CreateDisablePlayerInputRequest(DomainAspect domainAspect)
        {
            var entity = domainAspect.RequestsAspect.CreateRequest();
            domainAspect.InputAspect.DisablePlayerInputRequestPool.Add(entity);
            return entity;
        }
        
        public static ProtoEntity CreateEnablePlatformsInputRequest(DomainAspect domainAspect)
        {
            var entity = domainAspect.RequestsAspect.CreateRequest();
            domainAspect.InputAspect.EnablePlatformsInputRequestPool.Add(entity);
            return entity;
        }
        
        public static ProtoEntity CreateDisablePlatformsInputRequest(DomainAspect domainAspect)
        {
            var entity = domainAspect.RequestsAspect.CreateRequest();
            domainAspect.InputAspect.DisablePlatformsInputRequestPool.Add(entity);
            return entity;
        }
    }
}