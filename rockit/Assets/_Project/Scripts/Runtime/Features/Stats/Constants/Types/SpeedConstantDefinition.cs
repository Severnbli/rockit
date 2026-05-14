using _Project.Scripts.Runtime.Core.Infrastructure.Localization;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Types
{
    public sealed class SpeedConstantDefinition : ConstantDefinition
    {
        public override string Name() => LocalizationEntriesContracts.Const.Speed.Name;
        public override string Discoverer() => LocalizationEntriesContracts.Const.Speed.Discoverer;
        public override string Info() => LocalizationEntriesContracts.Const.Speed.Info;
    }
}