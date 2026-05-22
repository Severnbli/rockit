using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Graphics.UI.Icons.Types;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Monos;
using _Project.Scripts.Runtime.Features.World.Levels.Configs;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Shared;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class PrepareLevelCompletedWindowStarsOnLevelCompletedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        private readonly LevelCompletedWindow _lcWindow;
        private readonly AnimatableStarIconFactory _asiFactory;
        private readonly LevelsStatsService _lsService;
        private readonly LevelsConfig _lConfig;

        public PrepareLevelCompletedWindowStarsOnLevelCompletedRequestSystem(LevelCompletedWindow lcWindow, 
            AnimatableStarIconFactory asiFactory, LevelsStatsService lsService, LevelsConfig lConfig)
        {
            _lcWindow = lcWindow;
            _asiFactory = asiFactory;
            _lsService = lsService;
            _lConfig = lConfig;
        }

        public void Run()
        {
            if (_lrAspect.LevelCompletedRequests.IsEmptySlow()) return;
            
            _lcWindow.StarsContainer.RemoveChildren();
            _lcWindow.EarnedStars.Clear();
            
            var starsScore = _lsService.StarsScore;
            
            for (var i = 1; i <= _lConfig.MaxStarsPerLevel; i++)
            {
                var star = _asiFactory.Create(_lcWindow.StarsContainer.transform);
                if (i <= starsScore) _lcWindow.EarnedStars.Add(star);
            }
        }
    }
}