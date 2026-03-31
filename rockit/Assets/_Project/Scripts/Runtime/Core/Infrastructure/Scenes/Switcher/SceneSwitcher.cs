using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher
{
    public class SceneSwitcher : ISceneSwitcher
    {
        private readonly SceneSwitcherService _service;
        private AsyncOperation _loadingOperation;

        public SceneSwitcher(SceneSwitcherService service)
        {
            _service = service;
        }

        public async UniTask SwitchScene(string sceneName, bool switchOnLoad = true)
        {
            _loadingOperation.allowSceneActivation = false;

            await UniTask.CompletedTask;
            
            if (switchOnLoad) TrySwitchToLoadedScene();
        }

        public bool TrySwitchToLoadedScene()
        {
            if (_loadingOperation is null || !_service.Loaded) return false;
            
            _loadingOperation.allowSceneActivation = true;
            _loadingOperation = null;
            return true;
        }
    }
}