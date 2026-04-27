using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Shared.Utils.Infrastructure
{
    public static class SharedUtils
    {
        public static ProtoEntity CreateInitializeRequest(RequestsAspect aspect, bool fixedRun = false,
            ProtoPackedEntityWithWorld targetEntity = default, InitializeRequest prepared = default)
        {
            var entity = aspect.CreateRequest(aspect.SharedRequestsAspect.InitializeRequestPool, targetEntity, fixedRun,
                prepared);
            return entity;
        }
    }
}