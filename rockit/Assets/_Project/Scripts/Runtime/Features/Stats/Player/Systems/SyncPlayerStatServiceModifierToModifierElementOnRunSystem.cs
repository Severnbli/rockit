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
            _psService.WalkFactorModifier = _psService.WalkFactorModifierObserver.Element.Value.Value.Factor;
            _psService.JumpFactorModifier = _psService.JumpFactorModifierObserver.Element.Value.Value.Factor;
            _psService.DashFactorModifier = _psService.DashFactorModifierObserver.Element.Value.Value.Factor;
            _psService.DashQuantityModifier = _psService.DashQuantityModifierObserver.Element.Value.Value.Quantity;
        }
    }
}