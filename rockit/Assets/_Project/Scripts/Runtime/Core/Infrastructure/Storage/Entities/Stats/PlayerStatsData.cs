using System;
using _Project.Scripts.Runtime.Shared;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities.Stats
{
    [Serializable]
    public sealed class PlayerStatsData
    {
        public int WalkModifierIndex = ProjectContracts.ArrayEmptyInt;
        public int JumpModifierIndex = ProjectContracts.ArrayEmptyInt;
        public int DashModifierIndex = ProjectContracts.ArrayEmptyInt;
    }
}