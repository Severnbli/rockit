using System;
using _Project.Scripts.Runtime.Features.Stats.Shared;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities.Stats
{
    [Serializable]
    public sealed class PlayerStatsData
    {
        public int WalkFactorUpdateIndex = StatsSharedContracts.NullStatUpdateIndex;
        public int JumpFactorUpdateIndex = StatsSharedContracts.NullStatUpdateIndex;
        public int DashFactorUpdateIndex = StatsSharedContracts.NullStatUpdateIndex;
        public int DashQuantityUpdateIndex = StatsSharedContracts.NullStatUpdateIndex;
    }
}