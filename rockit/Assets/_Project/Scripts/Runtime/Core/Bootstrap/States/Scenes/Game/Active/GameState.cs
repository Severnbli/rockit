using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Requests;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Types;
using _Project.Scripts.Runtime.Shared.Utils.Features.Graphics;
using _Project.Scripts.Runtime.Shared.Utils.Features.Input;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active
{
    public class GameState : IPostControlsState
    {
        private readonly RequestsAspect _rAspect;
        private readonly PlayerCamera _pCamera;
        private readonly CameraSwitchAwaiter _csAwaiter;

        public GameState(RequestsAspect rAspect, PlayerCamera pCamera, CameraSwitchAwaiter csAwaiter)
        {
            _rAspect = rAspect;
            _pCamera = pCamera;
            _csAwaiter = csAwaiter;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            SwitchToPlayerCamera();
            await _csAwaiter.AwaitSwitch();
            
            PlayerInputUtils.CreateEnableRequest(_rAspect);
            PlatformsInputUtils.CreateEnableRequest(_rAspect);
            await UniTask.NextFrame();
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
            PlayerInputUtils.CreateDisableRequest(_rAspect);
            PlatformsInputUtils.CreateDisableRequest(_rAspect);
            await UniTask.NextFrame();
        }
    }
}