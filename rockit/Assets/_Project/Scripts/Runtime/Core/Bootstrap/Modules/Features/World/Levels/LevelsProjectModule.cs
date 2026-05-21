using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.World.Levels.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.World.Levels
{
    public sealed class LevelsProjectModule : BaseModule<LevelsProjectModule>
    {
        public LevelsProjectModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SyncCompletedLevelsDataToLevelsConfigOnInitSystem>();
            BindSystem<SendSpawnLevelRequestOnSpawnLevelToLoadRequestSystem>();
            BindSystem<UpdatePlatformsInputServiceProfileOnLevelSpawnedRequestSystem>();
        }
    }
}