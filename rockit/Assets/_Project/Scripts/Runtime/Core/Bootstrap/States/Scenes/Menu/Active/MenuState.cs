using _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Tools.Switcher;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Menu.Monos;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active
{
    public class MenuState : ISceneState
    {
        private readonly MenuWindow _mWindow;
        private readonly MenusCamera _mCamera;
        private readonly ICameraSwitcher _cSwitcher;

        public MenuState(MenuWindow mWindow, MenusCamera mCamera, ICameraSwitcher cSwitcher)
        {
            _mWindow = mWindow;
            _mCamera = mCamera;
            _cSwitcher = cSwitcher;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _cSwitcher.SwitchTo(_mCamera.Camera);
            await _mWindow.OpenAwait();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _mWindow.CloseAwait();
        }
    }
}