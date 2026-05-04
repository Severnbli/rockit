using System;
using System.Linq;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities;
using _Project.Scripts.Runtime.Features.Stats.Player.Configs;
using _Project.Scripts.Runtime.Features.Stats.Player.Services;
using _Project.Scripts.Runtime.Features.Stats.Shared;

namespace _Project.Scripts.Runtime.Shared.Extensions.Features.Stats
{
    public static class PlayerStatsExtensions
    {
        public static void ClampPlayerStatsEntityIndexes(this PlayerStats pStats, PlayerStatsConfig psConfig)
        {
            pStats.WalkModifierIndex = psConfig.WalkModifiers.Length == 0 || pStats.WalkModifierIndex < 0
                ? ProjectContracts.ArrayEmptyInt
                : Math.Clamp(pStats.WalkModifierIndex, 0, psConfig.WalkModifiers.Length - 1);
            
            pStats.JumpModifierIndex = psConfig.JumpModifiers.Length == 0 || pStats.JumpModifierIndex < 0
                ? ProjectContracts.ArrayEmptyInt
                : Math.Clamp(pStats.JumpModifierIndex, 0, psConfig.JumpModifiers.Length - 1);
            
            pStats.DashModifierIndex = psConfig.DashModifiers.Length == 0 || pStats.DashModifierIndex < 0
                ? ProjectContracts.ArrayEmptyInt
                : Math.Clamp(pStats.DashModifierIndex, 0, psConfig.DashModifiers.Length - 1);
        }

        public static void UpdatePlayerStatsService(this PlayerStatsService psService, PlayerStats pStats,
            PlayerStatsConfig psConfig)
        {
            psService.WalkModifier =
                psConfig.WalkModifiers.Any() && pStats.WalkModifierIndex != ProjectContracts.ArrayEmptyInt
                    ? psConfig.WalkModifiers[pStats.WalkModifierIndex]
                    : StatsSharedContracts.DefaultFloatModifier;
            
            psService.JumpModifier =
                psConfig.JumpModifiers.Any() && pStats.JumpModifierIndex != ProjectContracts.ArrayEmptyInt
                    ? psConfig.JumpModifiers[pStats.JumpModifierIndex]
                    : StatsSharedContracts.DefaultFloatModifier;
            
            psService.DashModifier =
                psConfig.DashModifiers.Any() && pStats.DashModifierIndex != ProjectContracts.ArrayEmptyInt
                    ? psConfig.DashModifiers[pStats.DashModifierIndex]
                    : StatsSharedContracts.DefaultFloatModifier;
        }
    }
}