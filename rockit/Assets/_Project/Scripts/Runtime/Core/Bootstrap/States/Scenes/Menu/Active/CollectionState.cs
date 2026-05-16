using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Requests;
using _Project.Scripts.Runtime.Features.Stats.Constants.Services;
using _Project.Scripts.Runtime.Shared.Utils.Features.Graphics;
using _Project.Scripts.Runtime.Shared.Utils.Features.Stats;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active
{
    public class CollectionState : ISceneState
    {
        private readonly ConstantDisplayWindowService _cdwService;
        private readonly RequestsAspect _rAspect;
        private readonly PlayerCamera _pCamera;

        public CollectionState(ConstantDisplayWindowService cdwService, RequestsAspect rAspect, PlayerCamera pCamera)
        {
            _cdwService = cdwService;
            _rAspect = rAspect;
            _pCamera = pCamera;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            ActivateConstantDisplayWindow();
            SwitchToPlayerCamera();
            await UniTask.NextFrame();
        }

        private void ActivateConstantDisplayWindow()
        {
            _cdwService.Active = true;
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
            _cdwService.Active = false;
            await UniTask.NextFrame();
        }
    }
}