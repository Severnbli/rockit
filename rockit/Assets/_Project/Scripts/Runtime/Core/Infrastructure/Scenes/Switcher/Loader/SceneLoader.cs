using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Loader
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask LoadScene(string sceneName)
        {
            await UniTask.CompletedTask;
        }
    }
}