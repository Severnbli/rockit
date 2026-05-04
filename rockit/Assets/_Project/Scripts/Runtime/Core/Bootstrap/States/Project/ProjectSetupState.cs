using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Project
{
    public class ProjectSetupState : IProjectSetupState
    {
        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            stateMachine.ChangeState<ISceneSetupState>().Forget();
            await UniTask.CompletedTask;
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await UniTask.CompletedTask;
        }
    }
}