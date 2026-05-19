using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Project.Monos;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Project
{
    public class ControlsState : IProjectState
    {
        private readonly ControlsWindow _cWindow;

        public ControlsState(ControlsWindow cWindow)
        {
            _cWindow = cWindow;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _cWindow.OpenAwait();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _cWindow.CloseAwait();
        }
    }
}