using System.Linq;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.World.Levels.Configs;
using _Project.Scripts.Runtime.Features.World.Levels.Monos;
using _Project.Scripts.Runtime.Features.World.Levels.Requests;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using _Project.Scripts.Runtime.Features.World.Levels.Types;
using _Project.Scripts.Runtime.Shared.Utils.Features.World;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class SpawnLevelOnSpawnLevelRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        private readonly LevelsService _lService;
        private readonly LevelFactory _lFactory;
        private readonly LevelsConfig _lConfig;

        public SpawnLevelOnSpawnLevelRequestSystem(LevelsService lService, LevelFactory lFactory, LevelsConfig lConfig)
        {
            _lService = lService;
            _lFactory = lFactory;
            _lConfig = lConfig;
        }

        public void Run()
        {
            var (e, ok) = _lrAspect.SpawnLevelRequests.FirstSlow();
            if (!ok) return;
            
            ref var slRequest = ref _lrAspect.SpawnLevelRequestPool.Get(e);
            var targetId = slRequest.LevelId;
            
            if (!_lConfig.Levels.ContainsKey(targetId)) targetId = _lConfig.Levels.FirstOrDefault().Key;
            
            if (!_lConfig.Levels.TryGetValue(targetId, out var lDefinition)) return;
            if (!TrySpawnLevel(ref slRequest, out var level)) return;

            var prepared = new LevelSpawnedRequest
            {
                LevelId = slRequest.LevelId,
                Level = level,
                Definition = lDefinition
            };

            LevelsUtils.CreateLevelSpawnedRequest(_rAspect, prepared);
        }

        private bool TrySpawnLevel(ref SpawnLevelRequest slRequest, out Level level)
        {
            _lService.LevelIdToSpawn = slRequest.LevelId;
            level = _lFactory.Create();
            return level != null;
        }
    }
}