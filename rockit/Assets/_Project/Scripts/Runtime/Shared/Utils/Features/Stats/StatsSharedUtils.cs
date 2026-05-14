using System.Collections.Generic;
using _Project.Scripts.Runtime.Features.Economy.Coins.Types;
using _Project.Scripts.Runtime.Features.Stats.Shared;
using _Project.Scripts.Runtime.Shared.Tools;
using _Project.Scripts.Runtime.Shared.Utils.Shared;

namespace _Project.Scripts.Runtime.Shared.Utils.Features.Stats
{
    public static class StatsSharedUtils
    {
        public static bool TryCreateModifierSequence(IReadOnlyList<FactorPaidWithCoins> data,
            out SequenceElement<FactorPaidWithCoinsElement> first)
        {
            return SequenceElementUtils.TryCreateMappedSequenceWithNull(
                data,
                x => new FactorPaidWithCoinsElement
                {
                    Value = x
                },
                () => new FactorPaidWithCoinsElement
                {
                    Index = StatsSharedContracts.NullStatUpdateIndex,
                    Value = new FactorPaidWithCoins
                    {
                        Factor = StatsSharedContracts.DefaultFloatFactorModifier
                    }
                },
                out first,
                true
            );
        }
        
        public static bool TryCreateModifierSequence(IReadOnlyList<QuantityPaidWithCoins> data,
            out SequenceElement<QuantityPaidWithCoinsElement> first)
        {
            return SequenceElementUtils.TryCreateMappedSequenceWithNull(
                data,
                x => new QuantityPaidWithCoinsElement
                {
                    Value = x
                },
                () => new QuantityPaidWithCoinsElement
                {
                    Index = StatsSharedContracts.NullStatUpdateIndex,
                    Value = new QuantityPaidWithCoins
                    {
                        Quantity = StatsSharedContracts.DefaultIntQuantityModifier
                    }
                },
                out first,
                true
            );
        }
    }
}