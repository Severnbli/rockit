using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Stats.Shared.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Stats.Shared
{
    public sealed class StatsSharedSceneModule : BaseModule<StatsSharedSceneModule>
    {
        public StatsSharedSceneModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<UpdateStarsTotalizersTextUisOnRunSystem>();
        }
    }
}