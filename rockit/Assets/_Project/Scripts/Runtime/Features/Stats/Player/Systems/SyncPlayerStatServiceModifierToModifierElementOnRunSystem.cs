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
            _psService.WalkFactorModifier = _psService.WalkFactorModifierElement.Value.Value.Factor;
            _psService.JumpFactorModifier = _psService.JumpFactorModifierElement.Value.Value.Factor;
            _psService.DashFactorModifier = _psService.DashFactorModifierElement.Value.Value.Factor;
            _psService.DashQuantityModifier = _psService.DashQuantityModifierElement.Value.Value.Quantity;
        }
    }
}