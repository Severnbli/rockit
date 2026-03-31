using System.ComponentModel;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Escort
{
    public class SceneSwitcherLoadingEscort : ISceneSwitcherLoadingEscort
    {
        public async UniTask EscortLoading(AsyncOperation operation, SceneSwitcherService service)
        {
            await UniTask.CompletedTask;
        }
    }
}