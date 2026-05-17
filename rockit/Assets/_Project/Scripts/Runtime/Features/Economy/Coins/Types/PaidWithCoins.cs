using System;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Types
{
    [Serializable]
    public class PaidWithCoins<T>
    {
        public int CoinsAmount;
        public T Value;
    }
}