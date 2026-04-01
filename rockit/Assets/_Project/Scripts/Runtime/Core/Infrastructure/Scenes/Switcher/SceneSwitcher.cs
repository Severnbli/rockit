using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Loader;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
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
            if (_service.LoadStatus != SceneLoadStatus.NotLoaded)
            {
                LogUtils.LogWarning($"Detect start loading {sceneName} scene invocation while another loading " +
                                    $"operation is still running");
                return;
            }
            
            _loadingOperation = await _loader.LoadScene(sceneName);
            
            if (switchOnLoad) TrySwitchToLoadedScene();
        }

        public bool TrySwitchToLoadedScene()
        {
            if (_loadingOperation is null || _service.LoadStatus != SceneLoadStatus.Loaded) return false;
            
            _loadingOperation.allowSceneActivation = true;
            _loadingOperation = null;
            _service.Reset();
            return true;
        }
    }
}