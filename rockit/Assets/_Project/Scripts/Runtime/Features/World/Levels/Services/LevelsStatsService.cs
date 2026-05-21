using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities.Economy;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities.Stats;

namespace _Project.Scripts.Runtime.Features.World.Levels.Services
{
    public sealed class LevelsStatsService
    {
        public int UsedTransforms;
        public int RemainTransforms;
        public int StarsScore;
        public Dictionary<int, CoinData> CachedCollectedCoins = new ();
        public Dictionary<int, ConstantData> CachedInvestigatedConstants = new ();
    }
}