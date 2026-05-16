using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Requests;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Menu.Monos;
using _Project.Scripts.Runtime.Shared.Utils.Features.Graphics;
using _Project.Scripts.Runtime.Shared.Utils.Features.Stats;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active
{
    public class CollectionState : ISceneState
    {
        private readonly RequestsAspect _rAspect;
        private readonly PlayerCinemachineCamera _pcCamera;
        private readonly CollectionWindow _cWindow;

        public CollectionState(RequestsAspect rAspect, PlayerCinemachineCamera pcCamera, CollectionWindow cWindow)
        {
            _rAspect = rAspect;
            _pcCamera = pcCamera;
            _cWindow = cWindow;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            ActivateConstantDisplayWindow();
            SwitchToPlayerCamera();
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
                Target = _pcCamera.Camera
            };
            CamerasUtils.CreateSwitchCameraRequest(_rAspect, prepared);
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _cWindow.CloseAwait();
        }
    }
}