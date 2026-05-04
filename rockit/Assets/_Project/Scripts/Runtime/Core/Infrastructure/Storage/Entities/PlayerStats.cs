using System;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities
{
    [Serializable]
    public sealed class PlayerStats
    {
        public int WalkModifierIndex = -1;
        public int JumpModifierIndex = -1;
        public int DashModifierIndex = -1;
    }
}