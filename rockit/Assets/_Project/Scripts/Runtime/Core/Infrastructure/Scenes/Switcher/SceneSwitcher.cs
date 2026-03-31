using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Loader;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher
{
    public class SceneSwitcher : ISceneSwitcher
    {
        private readonly SceneSwitcherService _service;
        private readonly ISceneLoader _loader;
        private AsyncOperation _loadingOperation;

        public SceneSwitcher(SceneSwitcherService service, ISceneLoader loader)
        {
            _service = service;
            _loader = loader;
        }

        public async UniTask SwitchScene(string sceneName, bool switchOnLoad = true)
        {
            if (!await _loader.TryLoadScene(sceneName, _loadingOperation)) return;
            
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