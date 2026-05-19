using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.World.Levels.Configs;
using _Project.Scripts.Runtime.Features.World.Levels.Monos;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.World.Levels.Types
{
    public class LevelFactory : BasePrefabFactory<Level, LevelFactoryCreateSettings>
    {
        private readonly LevelsContainer _lContainer;
        private readonly LevelsService _lService;
        private readonly LevelsConfig _lConfig;

        public LevelFactory(ProtoWorld world, LevelsContainer lContainer, LevelsService lService, 
            LevelsConfig lConfig) : base(world)
        {
            _lContainer = lContainer;
            _lService = lService;
            _lConfig = lConfig;
        }

        protected override GameObject GetPrefab()
        {
            return !_lConfig.Levels.TryGetValue(_lService.CurrLevelId, out var lDefinition) 
                ? null 
                : lDefinition.Prefab;
        }

        protected override Transform FallbackContainer() => _lContainer.GetContainer();
    }

    public struct LevelFactoryCreateSettings
    {
        
    }
}