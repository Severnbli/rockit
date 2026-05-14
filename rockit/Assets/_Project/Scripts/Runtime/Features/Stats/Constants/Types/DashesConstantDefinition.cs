using _Project.Scripts.Runtime.Core.Infrastructure.Localization;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Types
{
    public sealed class DashesConstantDefinition : ConstantDefinition
    {
        public override string Name() => LocalizationEntriesContracts.Const.Dashes.Name;
        public override string Discoverer() => LocalizationEntriesContracts.Const.Dashes.Discoverer;
        public override string Info() => LocalizationEntriesContracts.Const.Dashes.Info;
    }
}