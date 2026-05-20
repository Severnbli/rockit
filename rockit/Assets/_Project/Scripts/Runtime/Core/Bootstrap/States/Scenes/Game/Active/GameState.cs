using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Tools.Switcher;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Monos;
using _Project.Scripts.Runtime.Shared.Utils.Features.Input;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active
{
    public class GameState : IPostControlsState
    {
        private readonly RequestsAspect _rAspect;
        private readonly PlayerCamera _pCamera;
        private readonly GameWindow _gWindow;
        private readonly ICameraSwitcher _cSwitcher;

        public GameState(RequestsAspect rAspect, PlayerCamera pCamera, GameWindow gWindow, ICameraSwitcher cSwitcher)
        {
            _rAspect = rAspect;
            _pCamera = pCamera;
            _gWindow = gWindow;
            _cSwitcher = cSwitcher;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _cSwitcher.SwitchTo(_pCamera.Camera);
            
            PlayerInputUtils.CreateEnableRequest(_rAspect);
            PlatformsInputUtils.CreateEnableRequest(_rAspect);
            
            await _gWindow.OpenAwait();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _gWindow.CloseAwait();
            
            PlayerInputUtils.CreateDisableRequest(_rAspect);
            PlatformsInputUtils.CreateDisableRequest(_rAspect);
        }
    }
}