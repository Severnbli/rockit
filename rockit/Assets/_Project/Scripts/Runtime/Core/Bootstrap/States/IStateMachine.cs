using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States
{
    public interface IStateMachine
    {
        UniTask ChangeState<T>() where T : IState;
        UniTask ChangeState(IState state);
        UniTask EnterModalState<T>() where T : IState;
        UniTask EnterModalState(IState state);
        UniTask LeaveModalState<T>() where T : IState;
        UniTask LeaveModalState(IState state);
        void BootstrapSceneStates(params ISceneState[] states);
    }
}