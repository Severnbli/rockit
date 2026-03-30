using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes
{
    public interface ISceneSwitcher
    {
        UniTask SwitchScene(string sceneName);
    }
}