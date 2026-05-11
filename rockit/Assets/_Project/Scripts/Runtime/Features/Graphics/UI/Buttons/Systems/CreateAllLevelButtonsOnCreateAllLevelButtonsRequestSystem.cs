using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Types;
using _Project.Scripts.Runtime.Features.World.Levels.Configs;
using _Project.Scripts.Runtime.Shared.Utils.Features.Graphics;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Systems
{
    public sealed class CreateAllLevelButtonsOnCreateAllLevelButtonsRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly ButtonsRequestsAspect _brAspect;
        [DIRequests] private readonly RequestsAspect _rAspect;
        private readonly LevelsConfig _lConfig;
        private readonly LevelButtonFactory _lbFactory;
        private readonly DataProvider _dProvider;

        public CreateAllLevelButtonsOnCreateAllLevelButtonsRequestSystem(LevelsConfig lConfig,
            LevelButtonFactory lbFactory, DataProvider dProvider)
        {
            _lConfig = lConfig;
            _lbFactory = lbFactory;
            _dProvider = dProvider;
        }

        public void Run()
        {
            foreach (var e in _brAspect.CreateAllLevelButtonsRequests)
            {
                ref var calbRequest = ref _brAspect.CreateAllLevelButtonsRequestPool.Get(e);

                foreach (var kvp in _lConfig.Levels)
                {
                    var createSettings = ButtonsUtils.DefineLevelButtonCreateSettings(kvp.Key, kvp.Value, _dProvider);
                    _lbFactory.Create(calbRequest.At, createSettings);
                }
            }
        }
    }
}