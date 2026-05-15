using _Project.Scripts.Runtime.Features.Economy.Coins.Types;
using _Project.Scripts.Runtime.Features.Stats.Constants.Types;
using _Project.Scripts.Runtime.Shared.Tools;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Services
{
    public sealed class ConstantDisplayWindowService
    {
        public bool Show;
        public bool Active;
        public ConstantDefinition Definition;
        public SequenceElementObserver<IndexableFloatPaidWithCoins> Observer;
    }
}