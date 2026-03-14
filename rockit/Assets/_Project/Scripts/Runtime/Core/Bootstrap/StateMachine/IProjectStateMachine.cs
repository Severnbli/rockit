using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.StateMachine
{
    public interface IProjectStateMachine
    {
        UniTask ChangeState<T>() where T : IState;
        UniTask ChangeState(IState state);
    }
}