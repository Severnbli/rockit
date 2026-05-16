using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Requests;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Menu.Monos;
using _Project.Scripts.Runtime.Shared.Utils.Features.Graphics;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active
{
    public class MenuState : ISceneState
    {
        private readonly MenuWindow _mWindow;
        private readonly MenusCinemachineCamera _mcCamera;
        private readonly RequestsAspect _rAspect;

        public MenuState(MenuWindow mWindow, MenusCinemachineCamera mcCamera, RequestsAspect rAspect)
        {
            _mWindow = mWindow;
            _mcCamera = mcCamera;
            _rAspect = rAspect;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            SwitchToMenuCamera();
            await _mWindow.OpenAwait();
        }

        private void SwitchToMenuCamera()
        {
            var prepared = new SwitchCameraRequest
            {
                Target = _mcCamera.Camera
            };
            CamerasUtils.CreateSwitchCameraRequest(_rAspect, prepared);
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _mWindow.CloseAwait();
        }
    }
}