using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Stats.Player.Services;
using _Project.Scripts.Runtime.Features.Stats.Player.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Stats
{
    public sealed class PlayerStatsModule : BaseModule<PlayerStatsModule>
    {
        public PlayerStatsModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindServices()
        {
            base.BindServices();
            
            BindService<PlayerStatsService>();
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<ClampPlayerStatsDataIndexesOnInitSystem>();
            BindSystem<CreatePlayerStatsServiceModifiersSequencesOnInitSystem>();
            BindSystem<SyncPlayerStatServiceModifierToModifierElementOnRunSystem>();
        }
    }
}