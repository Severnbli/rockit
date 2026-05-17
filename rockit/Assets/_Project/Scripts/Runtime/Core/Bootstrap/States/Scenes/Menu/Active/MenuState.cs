using System.Threading;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Requests;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Types;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Menu.Monos;
using _Project.Scripts.Runtime.Shared.Utils.Features.Graphics;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active
{
    public class MenuState : ISceneState
    {
        private readonly MenuWindow _mWindow;
        private readonly MenusCamera _mCamera;
        private readonly RequestsAspect _rAspect;
        private readonly ICameraSwitchAwaiter _csAwaiter;
        private readonly CancellationToken _ct;

        public MenuState(MenuWindow mWindow, MenusCamera mCamera, RequestsAspect rAspect,
            ICameraSwitchAwaiter csAwaiter, CancellationToken ct)
        {
            _mWindow = mWindow;
            _mCamera = mCamera;
            _rAspect = rAspect;
            _csAwaiter = csAwaiter;
            _ct = ct;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            SwitchToMenuCamera();
            await _csAwaiter.AwaitSwitch(_ct);
            await _mWindow.OpenAwait();
        }

        private void SwitchToMenuCamera()
        {
            var prepared = new SwitchCameraRequest
            {
                Target = _mCamera.Camera
            };
            CamerasUtils.CreateSwitchCameraRequest(_rAspect, prepared);
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _mWindow.CloseAwait();
        }
    }
}