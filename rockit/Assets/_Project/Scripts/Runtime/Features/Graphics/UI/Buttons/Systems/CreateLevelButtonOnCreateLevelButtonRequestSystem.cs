using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Types;
using _Project.Scripts.Runtime.Features.World.Levels.Configs;
using _Project.Scripts.Runtime.Shared.Utils.Features.Graphics;
using _Project.Scripts.Runtime.Shared.Utils.Shared;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Systems
{
    public sealed class CreateLevelButtonOnCreateLevelButtonRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly ButtonsRequestsAspect _brAspect;
        private readonly LevelButtonFactory _lbFactory;
        private readonly DataProvider _dProvider;
        private readonly LevelsConfig _lConfig;

        public CreateLevelButtonOnCreateLevelButtonRequestSystem(LevelButtonFactory lbFactory, DataProvider dProvider,
            LevelsConfig lConfig)
        {
            _lbFactory = lbFactory;
            _dProvider = dProvider;
            _lConfig = lConfig;
        }

        public void Run()
        {
            foreach (var e in _brAspect.CreateLevelButtonRequests)
            {
                ref var clbRequest = ref _brAspect.CreateLevelButtonRequestPool.Get(e);
                if (!_lConfig.Levels.TryGetValue(clbRequest.LevelId, out var lDefinition)) continue;

                var createSettings =
                    ButtonsUtils.DefineLevelButtonCreateSettings(clbRequest.LevelId, lDefinition, _dProvider);

                _lbFactory.Create(clbRequest.At, createSettings);
            }
        }
    }
}