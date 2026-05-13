using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Stats.Shared.Services;
using _Project.Scripts.Runtime.Features.Stats.Shared.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Stats
{
    public sealed class StatsSharedModule : BaseModule<StatsSharedModule>
    {
        public StatsSharedModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindServices()
        {
            base.BindServices();
            
            BindService<GameStatsService>();
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<UpdateGameStatsServiceProgressOfPassageOnRunSystem>();
            BindSystem<UpdateGameStatsServiceTotalStarsOnRunSystem>();
        }
    }
}