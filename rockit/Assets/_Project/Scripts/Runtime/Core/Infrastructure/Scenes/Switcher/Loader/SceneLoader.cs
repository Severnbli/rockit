using System.Threading;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Escort;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Loader
{
    public class SceneLoader : ISceneLoader
    {
        private readonly CancellationToken _ct;
        private readonly SceneLoaderConfig _config;
        private readonly SceneSwitcherService _switcherService;
        private readonly ISceneLoadingEscort _loadingEscort;
        private readonly TimeService _timeService;

        public SceneLoader(SceneSwitcherService switcherService, ISceneLoadingEscort loadingEscort,
            TimeService timeService, SceneLoaderConfig config, CancellationToken ct)
        {
            _switcherService = switcherService;
            _loadingEscort = loadingEscort;
            _timeService = timeService;
            _config = config;
            _ct = ct;
        }

        public async UniTask<bool> TryLoadScene(string sceneName, AsyncOperation loadingOperation)
        {
            await UniTask.CompletedTask;
        }

        private async UniTask LoadScene(AsyncOperation operation)
        {
            var spentTime = await _timeService.GetUniTaskSpentTime(() => _loadingEscort.EscortLoading(operation));
            
            if (!_config.SimulateLoading) return;

            await UniTaskUtils.WaitForRemainingTime(spentTime, _config.SimulationLoadingDuration, _ct);
        }
    }
}