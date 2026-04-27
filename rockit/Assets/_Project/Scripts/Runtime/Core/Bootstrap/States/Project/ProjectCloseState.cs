using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Project
{
    public class ProjectCloseState : IProjectCloseState
    {
        public async UniTask OnEnter()
        {
            Application.Quit();
            await UniTask.CompletedTask;
        }

        public async UniTask OnLeave()
        {
            await UniTask.CompletedTask;
        }
    }
}