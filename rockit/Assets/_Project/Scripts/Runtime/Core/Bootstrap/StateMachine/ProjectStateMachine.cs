using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.StateMachine
{
    public class ProjectStateMachine : IProjectStateMachine
    {
        protected IState ActiveState;
        
        public ProjectStateMachine(IProjectSetupState state)
        {
            ChangeState(state);
        }
        
        public async UniTask ChangeState<T>() where T : IState
        {
            throw new System.NotImplementedException();
        }

        public async UniTask ChangeState(IState state)
        {
            if (ActiveState is not null) await ActiveState.OnLeave();
            ActiveState = state;
            if (ActiveState is not null) await ActiveState.OnEnter();
        }
    }
}