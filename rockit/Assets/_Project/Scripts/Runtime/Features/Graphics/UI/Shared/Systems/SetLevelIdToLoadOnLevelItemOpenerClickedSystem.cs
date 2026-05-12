using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.World.Levels;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Systems
{
    public sealed class SetLevelIdToLoadOnLevelItemOpenerClickedSystem : IProtoRunSystem
    {
        [DI] private readonly UISharedAspect _usAspect;
        [DI] private readonly LevelsAspect _lAspect;
        private readonly DataProvider _dProvider;

        public SetLevelIdToLoadOnLevelItemOpenerClickedSystem(DataProvider dProvider)
        {
            _dProvider = dProvider;
        }

        public void Run()
        {
            var (e, ok) = _usAspect.ClickedLevelItemSceneLoaders.FirstSlow();
            if (!ok) return;

            ref var liComponent = ref _lAspect.LevelItemComponentPool.Get(e);
            _dProvider.GameSceneData.LevelIdToLoad = liComponent.LevelId;
        }
    }
}