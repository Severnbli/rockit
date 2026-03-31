using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher
{
    public class SceneSwitcher : ISceneSwitcher
    {
        private CancellationToken _ct;
        private AsyncOperation _loadingOperation;

        public SceneSwitcher(CancellationToken ct)
        {
            _ct = ct;
        }

        public async UniTask SwitchScene(string sceneName)
        {
            await UniTask.CompletedTask;
        }
    }
}