using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.StateMachine
{
    public class StateMachine : IStateMachine
    {
        protected IState ActiveState;
        
        public StateMachine(IProjectSetupState state)
        {
            ChangeState(state);
        }
        
        public async UniTask ChangeState<T>() where T : IState
        {
            throw new System.NotImplementedException();
        }

        public async UniTask ChangeState(IState state)
        {
            throw new System.NotImplementedException();
        }
    }
}