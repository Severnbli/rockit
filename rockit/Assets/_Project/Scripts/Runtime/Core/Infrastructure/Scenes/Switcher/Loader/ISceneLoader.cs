using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Loader
{
    public interface ISceneLoader
    {
        UniTask<bool> TryLoadScene(string sceneName, AsyncOperation loadingOperation);
    }
}