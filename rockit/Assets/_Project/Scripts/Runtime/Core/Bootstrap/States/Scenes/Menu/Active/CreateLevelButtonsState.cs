using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Monos;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Requests;
using _Project.Scripts.Runtime.Shared.Utils.Features.Graphics;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active
{
    public class CreateLevelButtonsState : ISceneState
    {
        private readonly LevelButtonContainer _lbContainer;
        private readonly RequestsAspect _rAspect;

        public CreateLevelButtonsState(LevelButtonContainer lbContainer, RequestsAspect rAspect)
        {
            _lbContainer = lbContainer;
            _rAspect = rAspect;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            var prepared = new CreateAllLevelButtonsRequest
            {
                At = _lbContainer.transform
            };
            ButtonsUtils.CreateCreateAllLevelButtonsRequest(_rAspect, prepared);
            
            stateMachine.ChangeState<MenuState>().Forget();
            await UniTask.NextFrame();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await UniTask.NextFrame();
        }
    }
}