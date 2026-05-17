using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Monos;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Types;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Shared;
using Leopotam.EcsProto;
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

        public static ProtoEntity CreateSwitchSceneRequest(RequestsAspect aspect, SwitchSceneRequest prepared)
        {
            return aspect.CreateRequest(aspect.ScenesRequestsAspect.SwitchSceneRequestPool, prepared: prepared);
        }

        public static ProtoEntity CreateLoadLevelRequest(RequestsAspect aspect, LoadLevelRequest prepared)
        {
            return aspect.CreateRequest(aspect.ScenesRequestsAspect.LoadLevelRequestPool, prepared: prepared);
        }

        public static void InitializeScene()
        {
            GameObjectUtils.TryGetByType(out List<MonoInitializableOnSceneInitialize> initializables, false);

            foreach (var initializable in initializables)
            {
                initializable.Initialize();
            }
        }
    }
}