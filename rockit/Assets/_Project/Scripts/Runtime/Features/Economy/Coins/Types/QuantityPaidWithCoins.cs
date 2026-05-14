using System;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Types
{
    [Serializable]
    public class QuantityPaidWithCoins : PaidWithCoins
    {
        public int Quantity;
        
        public override string GetValueString() => Quantity.ToString();
    }
}