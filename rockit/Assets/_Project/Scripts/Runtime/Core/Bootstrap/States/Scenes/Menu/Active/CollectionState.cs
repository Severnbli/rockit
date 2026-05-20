using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Tools.Switcher;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Menu.Monos;
using _Project.Scripts.Runtime.Shared.Utils.Features.Input;
using _Project.Scripts.Runtime.Shared.Utils.Features.Stats;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active
{
    public class CollectionState : ISceneState
    {
        private readonly RequestsAspect _rAspect;
        private readonly PlayerCamera _pCamera;
        private readonly CollectionWindow _cWindow;
        private readonly ICameraSwitcher _cSwitcher;

        public CollectionState(RequestsAspect rAspect, PlayerCamera pCamera, CollectionWindow cWindow, 
            ICameraSwitcher cSwitcher)
        {
            _rAspect = rAspect;
            _pCamera = pCamera;
            _cWindow = cWindow;
            _cSwitcher = cSwitcher;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            ActivateConstantDisplayWindow();
            await _cSwitcher.SwitchTo(_pCamera.Camera);
            PlayerInputUtils.CreateEnableRequest(_rAspect);
            await _cWindow.OpenAwait();
        }

        private void ActivateConstantDisplayWindow()
        {
            ConstantsUtils.CreateShowConstantDisplayWindowRequest(_rAspect);
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            PlayerInputUtils.CreateDisableRequest(_rAspect);
            await _cWindow.CloseAwait();
        }
    }
}