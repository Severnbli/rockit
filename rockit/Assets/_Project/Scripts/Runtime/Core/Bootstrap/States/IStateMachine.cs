using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States
{
    public interface IStateMachine
    {
        UniTask ChangeState<T>() where T : IState;
        UniTask ChangeState(IState state);
        UniTask EnterModalState<T>() where T : IState;
        UniTask LeaveModalState<T>() where T : IState;
        void BootstrapSceneStates(params ISceneState[] states);
    }
}