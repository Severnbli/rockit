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

        public static ProtoEntity CreateSpawnLevelToLoadRequest(RequestsAspect aspect)
        {
            return aspect.CreateRequest(aspect.WorldSharedRequestsAspect.LevelsRequestsAspect
                .SpawnLevelToLoadRequestPool);
        }

        public static ProtoEntity CreateLevelSpawnedRequest(RequestsAspect aspect, LevelSpawnedRequest prepared)
        {
            return aspect.CreateRequest(aspect.WorldSharedRequestsAspect.LevelsRequestsAspect.LevelSpawnedRequestPool,
                prepared: prepared);
        }

        public static ProtoEntity CreateRecalculateLevelsStatsRequest(RequestsAspect aspect)
        {
            return aspect.CreateRequest(aspect.WorldSharedRequestsAspect.LevelsRequestsAspect
                .RecalculateLevelsStatsRequestPool);
        }
    }
}