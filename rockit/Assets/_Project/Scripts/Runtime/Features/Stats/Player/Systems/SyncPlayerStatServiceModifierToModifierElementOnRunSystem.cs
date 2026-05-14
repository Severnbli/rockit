using System;
using _Project.Scripts.Runtime.Features.Stats.Player.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Systems
{
    public sealed class SyncPlayerStatServiceModifierToModifierElementOnRunSystem : IProtoRunSystem
    {
        private readonly PlayerStatsService _psService;

        public SyncPlayerStatServiceModifierToModifierElementOnRunSystem(PlayerStatsService psService)
        {
            _psService = psService;
        }

        public void Run()
        {
            _psService.WalkFactorModifier = _psService.WalkFactorModifierObserver.Element.Value.Value;
            _psService.JumpFactorModifier = _psService.JumpFactorModifierObserver.Element.Value.Value;
            _psService.DashFactorModifier = _psService.DashFactorModifierObserver.Element.Value.Value;
            _psService.DashQuantityModifier = (int) _psService.DashQuantityModifierObserver.Element.Value.Value;
        }
    }
}