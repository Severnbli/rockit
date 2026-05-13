using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Requests;
using _Project.Scripts.Runtime.Features.World.Levels;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Systems
{
    public sealed class SendLoadLevelRequestOnClickedLevelItemSceneLoaderSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly UISharedAspect _usAspect;
        [DI] private readonly LevelsAspect _lAspect;

        public void Run()
        {
            var (e, ok) = _usAspect.ClickedLevelItemSceneLoaders.FirstSlow();
            if (!ok) return;

            ref var liComponent = ref _lAspect.LevelItemComponentPool.Get(e);

            var prepared = new LoadLevelRequest
            {
                Id = liComponent.LevelId,
            };
            ScenesUtils.CreateLoadLevelRequest(_rAspect, prepared);
        }
    }
}