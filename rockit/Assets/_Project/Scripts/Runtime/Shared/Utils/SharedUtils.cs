using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Requests;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Shared.Utils
{
    public static class SharedUtils
    {
        public static ProtoEntity CreateInitializeRunRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld targetEntity = default, InitializeRequest prepared = default)
        {
            var entity = aspect.CreateRequest(aspect.SharedRequestsAspect.InitializeRequestPool, targetEntity, false,
                prepared);
            return entity;
        }
        
        public static ProtoEntity CreateInitializeFixedRunRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld targetEntity = default, InitializeRequest prepared = default)
        {
            var entity = aspect.CreateRequest(aspect.SharedRequestsAspect.InitializeRequestPool, targetEntity, true,
                prepared);
            return entity;
        }
    }
}