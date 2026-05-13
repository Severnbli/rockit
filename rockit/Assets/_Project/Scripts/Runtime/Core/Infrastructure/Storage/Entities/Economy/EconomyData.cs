using System;
using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities.Economy
{
    [Serializable]
    public sealed class EconomyData
    {
        public int CoinsQuantity;
        public SortedDictionary<int, CoinData> CollectedCoins = new ();
    }
}