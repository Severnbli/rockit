using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Runtime.Shared.Utils
{
    public static class SceneLoaderUtils
    {
        public static bool TryStartLoading(string sceneName, AsyncOperation loadingOperation)
        {
            if (loadingOperation is not null)
            {
                LogUtils.LogWarning($"Detect start loading {sceneName} scene invocation while another loading " +
                                    $"operation is still running");
                return false;
            }
            
            loadingOperation = SceneManager.LoadSceneAsync(sceneName);
            if (loadingOperation is not null) return true;
            
            LogUtils.LogError($"Scene {sceneName} failed to load");
            return false;
        }
    }
}