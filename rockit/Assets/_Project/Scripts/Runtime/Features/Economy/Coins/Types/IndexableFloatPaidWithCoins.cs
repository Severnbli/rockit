using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Types.Indexes;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Types
{
    public class IndexableFloatPaidWithCoins : FloatPaidWithCoins, IIndexable
    {
        public int Index { get; set; }
    }
}