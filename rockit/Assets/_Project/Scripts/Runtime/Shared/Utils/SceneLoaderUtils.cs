using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Runtime.Shared.Utils
{
    public static class SceneLoaderUtils
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