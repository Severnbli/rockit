using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.World.Levels.Configs;
using _Project.Scripts.Runtime.Features.World.Levels.Monos;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.World.Levels.Types
{
    public class LevelFactory : BasePrefabFactory<Level, LevelFactoryCreateSettings>
    {
        private readonly DataProvider _dProvider;
        private readonly LevelsConfig _lConfig;
        private readonly LevelsContainer _lContainer;

        public LevelFactory(ProtoWorld world, DataProvider dProvider, LevelsConfig lConfig, 
            LevelsContainer lContainer) : base(world)
        {
            _dProvider = dProvider;
            _lConfig = lConfig;
            _lContainer = lContainer;
        }

        protected override GameObject GetPrefab()
        {
            return !_lConfig.Levels.TryGetValue(_dProvider.GameSceneData.LevelIdToLoad, out var lDefinition) 
                ? null 
                : lDefinition.Prefab;
        }

        protected override Transform FallbackContainer() => _lContainer.GetContainer();
    }

    public struct LevelFactoryCreateSettings
    {
        
    }
}