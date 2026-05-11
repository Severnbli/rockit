using System;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.World.Levels.Configs;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class SyncCompletedLevelsDataToLevelsConfigOnInitSystem : IProtoInitSystem
    {
        private readonly DataProvider _dProvider;
        private readonly LevelsConfig _lConfig;
        private readonly ListPool<int> _intListPool;

        public SyncCompletedLevelsDataToLevelsConfigOnInitSystem(DataProvider dProvider, LevelsConfig lConfig,
            IObjectDomain objDomain)
        {
            _dProvider = dProvider;
            _lConfig = lConfig;
            objDomain.Get(out _intListPool);
        }

        public void Init(IProtoSystems systems)
        {
            var gsData = _dProvider.GameSceneData;
            var keysToRemove = _intListPool.Spawn();

            foreach (var kvp in gsData.CompletedLevels)
            {
                if (!_lConfig.Levels.ContainsKey(kvp.Key))
                {
                    keysToRemove.Add(kvp.Key);
                    continue;
                }

                kvp.Value.Stars = Math.Clamp(
                    kvp.Value.Stars,
                    LevelsContracts.MinStarsQuantity,
                    _lConfig.MaxStarsPerLevel
                );
            }

            foreach (var key in keysToRemove)
            {
                gsData.CompletedLevels.Remove(key);
            }
            
            _intListPool.Despawn(keysToRemove);
        }
    }
}