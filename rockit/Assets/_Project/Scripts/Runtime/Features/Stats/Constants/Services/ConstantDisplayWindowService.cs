using _Project.Scripts.Runtime.Features.Economy.Coins.Types;
using _Project.Scripts.Runtime.Features.Stats.Constants.Types;
using _Project.Scripts.Runtime.Shared;
using _Project.Scripts.Runtime.Shared.Tools;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Services
{
    public sealed class ConstantDisplayWindowService
    {
        public bool Show;
        public bool Active;
        public bool Prepared;
        public int LastPreparedConstantId = ProjectContracts.NullIntId;
        public ConstantDefinition Definition;
        public FloatPaidWithCoins[] Array;
        public SequenceElementObserver<IndexableFloatPaidWithCoins> Observer;
    }
}