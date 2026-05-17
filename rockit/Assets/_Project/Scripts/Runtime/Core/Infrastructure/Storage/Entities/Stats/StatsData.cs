using System;
using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities.Stats
{
    [Serializable]
    public sealed class StatsData
    {
        public PlayerStatsData PlayerStatsData = new ();
        public Dictionary<int, ConstantData> InvestigatedConstants = new ();
    }
}