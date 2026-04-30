using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Systems
{
    public sealed class LoadLevelOnLoadLevelRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly ScenesRequestsAspect _srAspect;
        [DIRequests] private readonly RequestsAspect _rAspect;
        private readonly DataProvider _dProvider;

        public LoadLevelOnLoadLevelRequestSystem(DataProvider dProvider)
        {
            _dProvider = dProvider;
        }

        public void Run()
        {
            var (e, ok) = _srAspect.LoadLevelRequests.FirstSlow();
            if (!ok) return;
            
            ref var llRequest = ref _srAspect.LoadLevelRequestPool.Get(e);
            _dProvider.GameSceneData.LevelIdToLoad = llRequest.Id;

            var prepared = new SwitchSceneRequest
            {
                Target = ScenesContracts.GameScene
            };
            ScenesUtils.CreateSwitchSceneRequest(_rAspect, prepared);
        }
    }
}