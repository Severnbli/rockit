using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Menu.Monos;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active
{
    public class LevelSelectionState : ISceneState
    {
        private readonly LevelSelectionWindow _lsWindow;
        
        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _lsWindow.OpenAwait();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await UniTask.NextFrame();
        }
    }
}