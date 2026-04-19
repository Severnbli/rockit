using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Shared.Utils.Animations
{
    public static class CharactersAnimationsUtils
    {
        public static ProtoEntity CreateKillRequest(RequestsAspect aspect, ProtoWorld world, ProtoEntity entity)
        {
            return aspect.CreateRequest(aspect.CharactersAnimationsRequestsAspect.KillCharacterRequestPool, 
                world.PackEntityWithWorld(entity));
        }
        
        public static ProtoEntity CreateReviveRequest(RequestsAspect aspect, ProtoWorld world, ProtoEntity entity)
        {
            return aspect.CreateRequest(aspect.CharactersAnimationsRequestsAspect.ReviveCharacterRequestPool, 
                world.PackEntityWithWorld(entity));
        }
    }
}