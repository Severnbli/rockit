using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class PlayerExtensions
    {
        public static ProtoEntity AddPlayerTagToRequest(this ProtoEntity entity, RequestsAspect aspect)
        {
            aspect.SharedAspect.PlayerTagPool.Add(entity);
            return entity;
        }
    }
}