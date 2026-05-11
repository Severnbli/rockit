using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Requests;
using _Project.Scripts.Runtime.Features.World.Levels.Configs;
using _Project.Scripts.Runtime.Shared.Utils.Features.Graphics;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Systems
{
    public sealed class SendCreateLevelButtonRequestsOnCreateAllLevelButtonsRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly ButtonsRequestsAspect _brAspect;
        [DIRequests] private readonly RequestsAspect _rAspect;
        private readonly LevelsConfig _lConfig;

        public SendCreateLevelButtonRequestsOnCreateAllLevelButtonsRequestSystem(LevelsConfig lConfig)
        {
            _lConfig = lConfig;
        }

        public void Run()
        {
            foreach (var e in _brAspect.CreateAllLevelButtonsRequests)
            {
                ref var slbRequest = ref _brAspect.CreateAllLevelButtonsRequestPool.Get(e);

                foreach (var levelId in _lConfig.Levels.Keys)
                {
                    var prepared = new CreateLevelButtonRequest
                    {
                        At = slbRequest.At,
                        LevelId = levelId
                    };
                    
                    ButtonsUtils.CreateCreateLevelButtonRequest(_rAspect, prepared);
                }
            }
        }
    }
}