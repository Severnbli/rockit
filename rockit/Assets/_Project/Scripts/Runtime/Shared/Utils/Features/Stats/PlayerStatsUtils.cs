using System;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities.Stats;
using _Project.Scripts.Runtime.Features.Stats.Player.Configs;
using _Project.Scripts.Runtime.Features.Stats.Shared;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils.Features.Stats
{
    public static class PlayerStatsUtils
    {
        public static void ClampPlayerStatsDataIndexesToConfig(PlayerStatsData psData, PlayerStatsConfig psConfig)
        {
            psData.WalkFactorUpdateIndex = Math.Clamp(
                psData.WalkFactorUpdateIndex,
                StatsSharedContracts.NullStatUpdateIndex,
                psConfig.WalkFactorUpdates.Length
            );

            psData.JumpFactorUpdateIndex = Math.Clamp(
                psData.JumpFactorUpdateIndex,
                StatsSharedContracts.NullStatUpdateIndex,
                psConfig.JumpFactorUpdates.Length
            );

            psData.JumpFactorUpdateIndex = Math.Clamp(
                psData.JumpFactorUpdateIndex,
                StatsSharedContracts.NullStatUpdateIndex,
                psConfig.JumpFactorUpdates.Length
            );

            psData.DashQuantityUpdateIndex = Math.Clamp(
                psData.DashQuantityUpdateIndex,
                StatsSharedContracts.NullStatUpdateIndex,
                psConfig.DashQuantityUpdates.Length
            );
        }

        public static ProtoEntity CreateSyncPlayerStatsServiceToStorageRequest(RequestsAspect aspect)
        {
            return aspect.CreateRequest(aspect.PlayerStatsRequestsAspect.SyncPlayerStatsServiceToStorageRequestPool);
        }
    }
}