using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.World.Levels.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils.Features.World
{
    public static class LevelsUtils
    {
        public static ProtoEntity CreateSpawnLevelRequest(RequestsAspect aspect, SpawnLevelRequest prepared)
        {
            return aspect.CreateRequest(aspect.WorldSharedRequestsAspect.LevelsRequestsAspect.SpawnLevelRequestPool, 
                prepared: prepared);
        }
    }
}