using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class DestroyPrevLevelOnLevelSpawnedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        private readonly LevelsService _lService;

        public DestroyPrevLevelOnLevelSpawnedRequestSystem(LevelsService lService)
        {
            _lService = lService;
        }

        public void Run()
        {
            if (_lrAspect.LevelSpawnedRequests.IsEmptySlow()) return;
            Object.Destroy(_lService.CurrLevel.gameObject);
        }
    }
}