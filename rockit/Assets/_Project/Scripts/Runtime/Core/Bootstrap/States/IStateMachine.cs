using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States
{
    public interface IStateMachine
    {
        UniTask ChangeState<T>() where T : IState;
        UniTask ChangeState(IState state);
        UniTask OpenModalState<T>() where T : IModalState;
        UniTask CloseModalState<T>() where T : IModalState;
        void BootstrapSceneStates(params ISceneState[] states);
    }
}