using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Project
{
    public class ProjectSetupState : IProjectSetupState
    {
        private readonly IStateMachine _sMachine;

        public ProjectSetupState(IStateMachine sMachine)
        {
            _sMachine = sMachine;
        }

        public async UniTask OnEnter()
        {
            await UniTask.CompletedTask;
        }

        public async UniTask OnLeave()
        {
            _sMachine.ChangeState<ISceneSetupState>().Forget();
            await UniTask.CompletedTask;
        }
    }
}