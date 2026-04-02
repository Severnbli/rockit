using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher
{
    public interface ISceneSwitcher
    {
        UniTask SwitchScene(string sceneName, bool switchOnLoad = true);
        bool TrySwitchToLoadedScene();
    }
}