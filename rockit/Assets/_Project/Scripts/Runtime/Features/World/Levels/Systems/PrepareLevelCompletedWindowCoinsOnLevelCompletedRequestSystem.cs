using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Graphics.UI.Icons.Types;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Monos;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Shared;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class PrepareLevelCompletedWindowCoinsOnLevelCompletedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        private readonly LevelCompletedWindow _lcWindow;
        private readonly CoinIconFactory _ciFactory;
        private readonly LevelsStatsService _lsService;

        public PrepareLevelCompletedWindowCoinsOnLevelCompletedRequestSystem(LevelCompletedWindow lcWindow, 
            CoinIconFactory ciFactory, LevelsStatsService lsService)
        {
            _lcWindow = lcWindow;
            _ciFactory = ciFactory;
            _lsService = lsService;
        }

        public void Run()
        {
            if (_lrAspect.LevelCompletedRequests.IsEmptySlow()) return;
            
            _lcWindow.CoinsContainer.RemoveChildren();
            _lcWindow.CollectedCoins.Clear();
            
            var coinsCount = _lsService.CachedCollectedCoins.Count;
            
            for (var i = 0; i < coinsCount; i++)
            {
                var coin = _ciFactory.Create(_lcWindow.CoinsContainer.transform);
                coin.gameObject.SetActive(false);
                _lcWindow.CollectedCoins.Add(coin);
            }
        }
    }
}