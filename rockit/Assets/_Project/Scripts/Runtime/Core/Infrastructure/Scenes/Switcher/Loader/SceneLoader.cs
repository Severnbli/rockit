using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Escort;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Loader
{
    public class SceneLoader : ISceneLoader
    {
        private SceneSwitcherService _switcherService;
        private readonly ISceneLoadingEscort _loadingEscort;

        public SceneLoader(SceneSwitcherService switcherService, ISceneLoadingEscort loadingEscort)
        {
            _switcherService = switcherService;
            _loadingEscort = loadingEscort;
        }

        public async UniTask<bool> TryLoadScene(string sceneName, AsyncOperation loadingOperation)
        {
            await UniTask.CompletedTask;
        }
    }
}