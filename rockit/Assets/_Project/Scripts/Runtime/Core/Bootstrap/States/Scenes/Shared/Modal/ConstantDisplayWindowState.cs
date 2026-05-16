using _Project.Scripts.Runtime.Features.Stats.Constants.Monos;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Shared.Modal
{
    public class ConstantDisplayWindowState : IConstantDisplayState
    {
        private readonly ConstantDisplayWindow _cdwWindow;

        public ConstantDisplayWindowState(ConstantDisplayWindow cdwWindow)
        {
            _cdwWindow = cdwWindow;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _cdwWindow.OpenAwait();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _cdwWindow.CloseAwait();
        }
    }
}