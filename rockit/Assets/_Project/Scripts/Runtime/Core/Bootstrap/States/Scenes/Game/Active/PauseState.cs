using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Monos;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active
{
    public class PauseState : ISceneState
    {
        private readonly PauseWindow _pWindow;

        public PauseState(PauseWindow pWindow)
        {
            _pWindow = pWindow;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _pWindow.OpenAwait();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _pWindow.CloseAwait();
        }
    }
}