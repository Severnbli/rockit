using System;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities.Stats;
using _Project.Scripts.Runtime.Features.Economy.Coins.Types;
using _Project.Scripts.Runtime.Features.Stats.Constants.Types;
using _Project.Scripts.Runtime.Features.Stats.Player.Configs;
using _Project.Scripts.Runtime.Features.Stats.Player.Services;
using _Project.Scripts.Runtime.Features.Stats.Shared;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Tools;
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
        
        public static bool TryGetObserverByConstantDefinition(ConstantDefinition def, PlayerStatsService psService, 
            out SequenceElementObserver<IndexableFloatPaidWithCoins> observer)
        {
            observer = null;
            
            switch (def)
            {
                case SpeedConstantDefinition:
                {
                    observer = psService.WalkFactorModifierObserver;
                    break;
                }
                case FlightsConstantDefinition:
                {
                    observer = psService.JumpFactorModifierObserver;
                    break;
                }
                case DashesConstantDefinition:
                {
                    observer = psService.DashFactorModifierObserver;
                    break;
                }
                case MultiConstantDefinition:
                {
                    observer = psService.DashQuantityModifierObserver;
                    break;
                }
                default:
                {
                    return false;
                }
            }

            return true;
        }
    }
}