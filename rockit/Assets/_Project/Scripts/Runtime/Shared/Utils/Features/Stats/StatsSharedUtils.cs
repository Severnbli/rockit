using System.Collections.Generic;
using _Project.Scripts.Runtime.Features.Economy.Coins.Types;
using _Project.Scripts.Runtime.Features.Stats.Shared;
using _Project.Scripts.Runtime.Shared.Tools;
using _Project.Scripts.Runtime.Shared.Utils.Shared;

namespace _Project.Scripts.Runtime.Shared.Utils.Features.Stats
{
    public static class StatsSharedUtils
    {
        public static void CreateModifierSequence(IReadOnlyList<FloatPaidWithCoins> data,
            out SequenceElement<IndexableFloatPaidWithCoins> first)
        {
            
            SequenceElementUtils.TryCreateMappedSequenceWithNull(
                data,
                (x, i) => new IndexableFloatPaidWithCoins
                {
                    Value = x.Value,
                    Index = i
                },
                () => new IndexableFloatPaidWithCoins
                {
                    Index = StatsSharedContracts.NullStatUpdateIndex,
                    Value = StatsSharedContracts.DefaultFloatFactorModifier
                },
                out first,
                true
            );
        }
        
        public static void CreateModifierSequence(IReadOnlyList<IntPaidWithCoins> data,
            out SequenceElement<IndexableIntPaidWithCoins> first)
        {
            SequenceElementUtils.TryCreateMappedSequenceWithNull(
                data,
                (x, i) => new IndexableIntPaidWithCoins
                {
                    Value = x.Value,
                    Index = i
                },
                () => new IndexableIntPaidWithCoins
                {
                    Index = StatsSharedContracts.NullStatUpdateIndex,
                    Value = StatsSharedContracts.DefaultIntQuantityModifier
                },
                out first,
                true
            );
        }
    }
}