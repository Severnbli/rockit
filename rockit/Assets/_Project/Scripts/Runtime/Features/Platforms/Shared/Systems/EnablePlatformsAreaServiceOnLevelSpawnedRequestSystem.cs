using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Services;
using _Project.Scripts.Runtime.Features.World.Levels;
using _Project.Scripts.Runtime.Shared.Utils.Features;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Systems
{
    public sealed class EnablePlatformsAreaServiceOnLevelSpawnedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        private readonly PlatformsAreaService _paService;

        public EnablePlatformsAreaServiceOnLevelSpawnedRequestSystem(PlatformsAreaService paService)
        {
            _paService = paService;
        }

        public void Run()
        {
            if (_lrAspect.LevelSpawnedRequests.IsEmptySlow()) return;

            _paService.Enabled = true;
            PlatformsUtils.CreatePlatformsAreaServiceEnabledRequests(_rAspect);
        }
    }
}