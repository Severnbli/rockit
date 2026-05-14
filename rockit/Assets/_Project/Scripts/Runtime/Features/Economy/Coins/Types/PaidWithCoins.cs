using System;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Types
{
    [Serializable]
    public abstract class PaidWithCoins
    {
        public int CoinsAmount;
        public abstract string GetValueString();
    }
}