using System.Threading;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Requests;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Types;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Menu.Monos;
using _Project.Scripts.Runtime.Shared.Utils.Features.Graphics;
using _Project.Scripts.Runtime.Shared.Utils.Features.Stats;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active
{
    public class CollectionState : ISceneState
    {
        private readonly RequestsAspect _rAspect;
        private readonly PlayerCamera _pCamera;
        private readonly CollectionWindow _cWindow;
        private readonly ICameraSwitchAwaiter _csAwaiter;
        private readonly CancellationToken _ct;

        public CollectionState(RequestsAspect rAspect, PlayerCamera pCamera, CollectionWindow cWindow, 
            ICameraSwitchAwaiter csAwaiter, CancellationToken ct)
        {
            _rAspect = rAspect;
            _pCamera = pCamera;
            _cWindow = cWindow;
            _csAwaiter = csAwaiter;
            _ct = ct;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            ActivateConstantDisplayWindow();
            SwitchToPlayerCamera();
            await _csAwaiter.AwaitSwitch(_ct);
            await _cWindow.OpenAwait();
        }

        private void ActivateConstantDisplayWindow()
        {
            ConstantsUtils.CreateShowConstantDisplayWindowRequest(_rAspect);
        }

        private void SwitchToPlayerCamera()
        {
            var prepared = new SwitchCameraRequest
            {
                Target = _pCamera.Camera
            };
            CamerasUtils.CreateSwitchCameraRequest(_rAspect, prepared);
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _cWindow.CloseAwait();
        }
    }
}