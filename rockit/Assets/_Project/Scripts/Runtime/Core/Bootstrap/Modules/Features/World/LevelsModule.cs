using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.World.Levels.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.World
{
    public sealed class LevelsModule : BaseModule<LevelsModule>
    {
        public LevelsModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SyncCompletedLevelsDataToLevelsConfigOnInitSystem>();
        }
    }
}