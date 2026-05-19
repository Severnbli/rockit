using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.World.Levels.Requests;
using _Project.Scripts.Runtime.Shared.Utils.Features.World;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class SendSpawnLevelRequestOnSpawnLevelToLoadRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        private readonly DataProvider _dProvider;

        public SendSpawnLevelRequestOnSpawnLevelToLoadRequestSystem(DataProvider dProvider)
        {
            _dProvider = dProvider;
        }

        public void Run()
        {
            if (_lrAspect.SpawnLevelToLoadRequests.IsEmptySlow()) return;

            var prepared = new SpawnLevelRequest
            {
                LevelId = _dProvider.GameSceneData.LevelIdToLoad
            };
            
            LevelsUtils.CreateSpawnLevelRequest(_rAspect, prepared);
        }
    }
}