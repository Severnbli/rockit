using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using _Project.Scripts.Runtime.Features.World.Levels.Systems;
using _Project.Scripts.Runtime.Features.World.Levels.Types;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.World.Levels
{
    public sealed class LevelsSceneModule : BaseModule<LevelsSceneModule>
    {
        public LevelsSceneModule(IDomain domain) : base(domain)
        {
        }

        protected override void RegisterBindings()
        {
            base.RegisterBindings();

            Container.Bind<LevelFactory>().AsSingle();
        }
        
        protected override void BindServices()
        {
            base.BindServices();
            
            BindService<LevelsService>();
            BindService<LevelsStatsService>();
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SpawnLevelOnSpawnLevelRequestSystem>();
            BindSystem<DestroyPrevLevelOnLevelSpawnedRequestSystem>();
            BindSystem<ResetLevelsServiceOnLevelSpawnedRequestSystem>();
            BindSystem<ResetLevelsStatsServiceOnLevelSpawnedRequestSystem>();
            BindSystem<InstallLevelToLevelsServiceOnLevelSpawnedRequestSystem>();
            BindSystem<SendPlacePlayerRequestOnLevelSpawnedRequestSystem>();
            BindSystem<SendRecalculateLevelsStatsRequestOnLevelSpawnedRequestSystem>();
            BindSystem<UpdateLevelsStatsServiceUsedTransformsOnAnyPlatformsTriggeredRequestSystem>();
            BindSystem<RecalculateLevelsStatsOnRecalculateLevelsStatsRequestSystem>();
            BindSystem<UpdateStarsScoreStatsTextUiOnRunSystem>();
            BindSystem<UpdateRemainTransformsStatsTextUiOnRunSystem>();
            BindSystem<CacheCollectedCoinOnCoinTriggeredRequestSystem>();
            BindSystem<CacheCollectedConstantsOnConstantCollectedRequestSystem>();
            BindSystem<PersistLevelsStatsServiceCachedCollectedCoinsOnLevelCompletedRequestSystem>();
            BindSystem<PersistLevelsStatsServiceCachedInvestigatedConstantsOnLevelCompletedRequestSystem>();
            BindSystem<PersistLevelsStatsServiceStarsScoreOnLevelCompletedRequestSystem>();
            BindSystem<SendLevelCompletedRequestOnTeleporterTriggeredRequestSystem>();
        }
    }
}