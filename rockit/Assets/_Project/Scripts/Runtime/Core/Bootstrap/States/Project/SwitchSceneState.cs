using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Project
{
    public class SwitchSceneState : IProjectState
    {
        public async UniTask OnEnter()
        {
            await UniTask.CompletedTask;
        }

        public async UniTask OnLeave()
        {
            await UniTask.CompletedTask;
        }
    }
}