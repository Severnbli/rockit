using System.Threading;
using _Project.Scripts.Runtime.Shared.Extensions;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher
{
    public class SceneSwitcher : ISceneSwitcher
    {
        private CancellationToken _ct;
        private SceneSwitcherConfig _config;
        private SceneSwitcherService _service;
        private AsyncOperation _loadingOperation;

        public SceneSwitcher(CancellationToken ct, SceneSwitcherConfig config, SceneSwitcherService service)
        {
            _ct = ct;
            _config = config;
            _service = service;
        }

        public async UniTask SwitchScene(string sceneName)
        {
            if (_loadingOperation is not null) return;
            
            _loadingOperation = SceneManager.LoadSceneAsync(sceneName);
            if (_loadingOperation is null) return;
            
            _loadingOperation.allowSceneActivation = false;

            while (!_loadingOperation.isDone)
            {
                if (_ct.IsCancellationRequested) return;
                
                _service.SetProgress(_loadingOperation);

                if (_loadingOperation.Completed()) break;
                
                await UniTask.Yield();
            }
            
            _service.SetMaxProgress();
            _service.Loaded = true;
            _loadingOperation.allowSceneActivation = true;
        }
    }
}