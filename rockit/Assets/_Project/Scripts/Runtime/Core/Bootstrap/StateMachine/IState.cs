using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.StateMachine
{
    public interface IState
    {
        UniTask OnEnter();
        UniTask OnLeave();
    }
}