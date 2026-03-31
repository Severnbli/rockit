using UnityEngine;
using System.Threading;
using _Project.Scripts.Runtime.Shared.Extensions;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Escort
{
    public class SceneLoadingEscort : ISceneLoadingEscort
    {
        private CancellationToken _ct;

        public SceneLoadingEscort(CancellationToken ct)
        {
            _ct = ct;
        }

        public async UniTask EscortLoading(AsyncOperation operation, SceneSwitcherService service)
        {
            if (operation is null) return;
            
            while (!operation.isDone)
            {
                if (_ct.IsCancellationRequested) return;
                
                service.SetProgress(operation);
                
                if (operation.Completed()) break;
                
                await UniTask.Yield();
            }
        }
    }
}