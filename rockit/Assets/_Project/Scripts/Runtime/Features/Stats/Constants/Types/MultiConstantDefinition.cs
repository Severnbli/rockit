using _Project.Scripts.Runtime.Core.Infrastructure.Localization;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Types
{
    public sealed class MultiConstantDefinition : ConstantDefinition
    {
        public override string Name() => LocalizationEntriesContracts.Const.Multi.Name;
        public override string Discoverer() => LocalizationEntriesContracts.Const.Multi.Discoverer;
        public override string Info() => LocalizationEntriesContracts.Const.Multi.Info;
    }
}