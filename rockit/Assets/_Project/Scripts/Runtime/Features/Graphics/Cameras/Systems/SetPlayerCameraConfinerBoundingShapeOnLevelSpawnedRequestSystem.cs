using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos;
using _Project.Scripts.Runtime.Features.World.Levels;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Systems
{
    public sealed class SetPlayerCameraConfinerBoundingShapeOnLevelSpawnedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        private readonly PlayerCamera _pCamera;

        public SetPlayerCameraConfinerBoundingShapeOnLevelSpawnedRequestSystem(PlayerCamera pCamera)
        {
            _pCamera = pCamera;
        }

        public void Run()
        {
            var (e, ok) = _lrAspect.LevelSpawnedRequests.FirstSlow();
            if (!ok) return;

            ref var lsRequest = ref _lrAspect.LevelSpawnedRequestPool.Get(e);
            _pCamera.Confiner.SetBoundingShape(lsRequest.Level.CameraBounds);
        }
    }
}