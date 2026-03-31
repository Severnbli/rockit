using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Escort;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Loader
{
    public class SceneLoader : ISceneLoader
    {
        private readonly SceneSwitcherService _switcherService;
        private readonly ISceneLoadingEscort _loadingEscort;
        private readonly TimeService _timeService;

        public SceneLoader(SceneSwitcherService switcherService, ISceneLoadingEscort loadingEscort, TimeService timeService)
        {
            _switcherService = switcherService;
            _loadingEscort = loadingEscort;
            _timeService = timeService;
        }

        public async UniTask<bool> TryLoadScene(string sceneName, AsyncOperation loadingOperation)
        {
            await UniTask.CompletedTask;
        }
    }
}