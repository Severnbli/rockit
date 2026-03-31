using System.Threading;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher
{
    public class SceneSwitcher : ISceneSwitcher
    {
        private readonly CancellationToken _ct;
        private readonly SceneSwitcherConfig _config;
        private readonly SceneSwitcherService _service;
        private readonly TimeService _timeService;
        private AsyncOperation _loadingOperation;

        public SceneSwitcher(CancellationToken ct, SceneSwitcherConfig config, SceneSwitcherService service, TimeService timeService)
        {
            _ct = ct;
            _config = config;
            _service = service;
            _timeService = timeService;
        }

        public async UniTask LoadScene(string sceneName, bool switchOnLoad = true)
        {
            await UniTask.CompletedTask;
        }

        private bool TryStartLoading(string sceneName, out AsyncOperation operation)
        {
            operation = null;
            
            if (_loadingOperation is not null)
            {
                LogUtils.LogWarning($"Detect LoadScene method for {sceneName} scene invocation while another loading " +
                                    $"operation is still running");
                return false;
            }

            operation = SceneManager.LoadSceneAsync(sceneName);
            if (operation is not null) return true;
            
            LogUtils.LogError($"Scene {sceneName} failed to load");
            return false;
        }

        private async UniTask EscortSceneLoading()
        {
            while (!_loadingOperation.isDone)
            {
                if (_ct.IsCancellationRequested) return;
                
                _service.SetProgress(_loadingOperation);
                
                if (_loadingOperation.Completed()) break;
                
                await UniTask.Yield();
            }
        }
    }
}