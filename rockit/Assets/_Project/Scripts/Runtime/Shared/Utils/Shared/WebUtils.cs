using System;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

namespace _Project.Scripts.Runtime.Shared.Utils.Shared
{
    public static class WebUtils
    {
        public static async UniTask<string> GetText(string url)
        {
            using var request = UnityWebRequest.Get(url);

            try
            {
                await request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.Success) return request.downloadHandler.text;
            }
            catch (Exception e)
            {
                LogUtils.LogError($"Error: {e}");
                throw;
            }

            LogUtils.LogError($"Failed to get text. Url: {url}. Error: {request.error}");
            
            return string.Empty;
        }
    }
}