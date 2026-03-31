using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Loader
{
    public interface ISceneLoader
    {
        UniTask LoadScene(string sceneName, AsyncOperation loadingOperation);
    }
}