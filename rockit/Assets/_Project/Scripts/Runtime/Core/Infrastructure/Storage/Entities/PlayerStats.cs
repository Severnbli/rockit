using System;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities
{
    [Serializable]
    public sealed class PlayerStats
    {
        public int WalkModifierIndex;
        public int JumpModifierIndex;
        public int DashModifierIndex;
    }
}