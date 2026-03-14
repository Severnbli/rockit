using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.StateMachine
{
    public interface IStateMachine
    {
        UniTask ChangeState<T>() where T : IState;
    }
}