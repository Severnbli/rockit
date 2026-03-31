using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Loader
{
    public interface ISceneLoader
    {
        UniTask LoadScene(string sceneName, bool switchOnLoad = true);
    }
}