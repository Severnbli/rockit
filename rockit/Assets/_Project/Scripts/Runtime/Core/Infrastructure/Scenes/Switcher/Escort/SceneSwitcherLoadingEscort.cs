using System.ComponentModel;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Escort
{
    public class SceneSwitcherLoadingEscort : ISceneSwitcherLoadingEscort
    {
        private CancellationToken _ct;

        public SceneSwitcherLoadingEscort(CancellationToken ct)
        {
            _ct = ct;
        }

        public async UniTask EscortLoading(AsyncOperation operation, SceneSwitcherService service)
        {
            await UniTask.CompletedTask;
        }
    }
}