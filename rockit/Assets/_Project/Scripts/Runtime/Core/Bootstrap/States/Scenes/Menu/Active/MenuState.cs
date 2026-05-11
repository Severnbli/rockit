using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Monos.Defined.Menu;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active
{
    public class MenuState : ISceneState
    {
        private readonly MenuWindow _window;

        public MenuState(MenuWindow window)
        {
            _window = window;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _window.OpenAwait();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _window.CloseAwait();
            await UniTask.NextFrame();
        }
    }
}