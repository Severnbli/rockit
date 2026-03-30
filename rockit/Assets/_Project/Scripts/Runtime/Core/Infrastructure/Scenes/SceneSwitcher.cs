using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes
{
    public class SceneSwitcher : ISceneSwitcher
    {
        public async UniTask SwitchScene(string sceneName)
        {
            await UniTask.CompletedTask;
        }
    }
}