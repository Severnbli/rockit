using _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Tools.Switcher;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Monos;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active
{
    public class PauseState : ISceneState
    {
        private readonly PauseWindow _pWindow;
        private readonly MenusCamera _mCamera;
        private readonly ICameraSwitcher _cSwitcher;

        public PauseState(PauseWindow pWindow, MenusCamera mCamera, ICameraSwitcher cSwitcher)
        {
            _pWindow = pWindow;
            _mCamera = mCamera;
            _cSwitcher = cSwitcher;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _cSwitcher.SwitchTo(_mCamera.Camera);
            await _pWindow.OpenAwait();
        }
        
        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _pWindow.CloseAwait();
        }
    }
}