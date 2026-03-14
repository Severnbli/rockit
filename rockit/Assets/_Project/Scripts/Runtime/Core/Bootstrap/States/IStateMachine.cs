using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States
{
    public interface IStateMachine
    {
        UniTask ChangeState<T>() where T : IState;
        UniTask ChangeState(IState state);
        void SetupSceneStates(params IState[] states);
    }
}