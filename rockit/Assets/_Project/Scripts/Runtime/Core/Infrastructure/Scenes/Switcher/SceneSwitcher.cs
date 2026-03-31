using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

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

        public async UniTask LoadScene(string sceneName)
        {
            await UniTask.CompletedTask;
        }
    }
}