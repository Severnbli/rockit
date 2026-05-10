using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Defined;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Defined.Menu;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active
{
    public class MenuWindowState : ISceneState
    {
        private readonly MenuWindow _window;

        public MenuWindowState(MenuWindow window)
        {
            _window = window;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _window.Open();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _window.Close();
            await UniTask.NextFrame();
        }
    }
}