using _Project.Scripts.Runtime.Shared.Utils.Shared;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Runtime.Shared.Utils.Infrastructure
{
    public static class ScenesUtils
    {
        public static bool TryStartLoading(string sceneName, out AsyncOperation loadingOperation)
        {
            loadingOperation = SceneManager.LoadSceneAsync(sceneName);
            if (loadingOperation is not null) return true;
            
            LogUtils.LogError($"Scene {sceneName} failed to load");
            return false;
        }
    }
}