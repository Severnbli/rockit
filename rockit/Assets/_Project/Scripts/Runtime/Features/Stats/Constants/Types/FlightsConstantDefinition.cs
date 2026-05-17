using System;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Types
{
    [Serializable]
    public sealed class FlightsConstantDefinition : ConstantDefinition
    {
        public override string Name() => LocalizationEntriesContracts.Const.Flights.Name;
        public override string Discoverer() => LocalizationEntriesContracts.Const.Flights.Discoverer;
        public override string Info() => LocalizationEntriesContracts.Const.Flights.Info;
    }
}