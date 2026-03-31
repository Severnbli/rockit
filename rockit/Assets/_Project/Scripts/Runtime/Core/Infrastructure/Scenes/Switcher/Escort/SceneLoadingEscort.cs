using UnityEngine;
using System.Threading;
using _Project.Scripts.Runtime.Shared.Extensions;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Escort
{
    public class SceneLoadingEscort : ISceneLoadingEscort
    {
        private readonly CancellationToken _ct;
        private readonly SceneSwitcherService _service;

        public SceneLoadingEscort(CancellationToken ct, SceneSwitcherService service)
        {
            _ct = ct;
            _service = service;
        }

        public async UniTask EscortLoading(AsyncOperation operation)
        {
            if (operation is null) return;
            
            while (!operation.isDone)
            {
                if (_ct.IsCancellationRequested) return;
                
                _service.SetProgress(operation);
                
                if (operation.Completed()) break;
                
                await UniTask.Yield();
            }
        }
    }
}