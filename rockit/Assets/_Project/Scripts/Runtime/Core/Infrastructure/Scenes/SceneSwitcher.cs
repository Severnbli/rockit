using System.Threading;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes
{
    public class SceneSwitcher : ISceneSwitcher
    {
        private CancellationToken _ct;

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