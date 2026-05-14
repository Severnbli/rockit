using System;
using System.Globalization;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Types
{
    [Serializable]
    public class FactorPaidWithCoins : PaidWithCoins
    {
        public float Factor;

        public override string GetValueString() => Factor.ToString("F", CultureInfo.InvariantCulture);
    }
}