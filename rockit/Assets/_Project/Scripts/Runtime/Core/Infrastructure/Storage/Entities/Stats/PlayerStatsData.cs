using System;
using _Project.Scripts.Runtime.Shared;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities.Stats
{
    [Serializable]
    public sealed class PlayerStatsData
    {
        public int WalkFactorUpdateIndex = ProjectContracts.ArrayEmptyInt;
        public int JumpFactorUpdateIndex = ProjectContracts.ArrayEmptyInt;
        public int DashFactorUpdateIndex = ProjectContracts.ArrayEmptyInt;
        public int DashQuantityUpdateIndex = ProjectContracts.ArrayEmptyInt;
    }
}