using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Monos.Defined.Menu;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active
{
    public class MenuState : ISceneState
    {
        private readonly MenuWindow _mWindow;

        public MenuState(MenuWindow mWindow)
        {
            _mWindow = mWindow;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _mWindow.OpenAwait();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _mWindow.CloseAwait();
            await UniTask.NextFrame();
        }
    }
}