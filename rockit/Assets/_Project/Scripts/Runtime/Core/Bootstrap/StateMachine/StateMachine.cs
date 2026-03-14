using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.StateMachine
{
    public class StateMachine : IStateMachine
    {
        protected IState ActiveState;
        
        public UniTask ChangeState<T>() where T : IState
        {
            throw new System.NotImplementedException();
        }
    }
}