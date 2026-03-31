using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Loader
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask<bool> TryLoadScene(string sceneName, AsyncOperation loadingOperation)
        {
            await UniTask.CompletedTask;
        }
    }
}