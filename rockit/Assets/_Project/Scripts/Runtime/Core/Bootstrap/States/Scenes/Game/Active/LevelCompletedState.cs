using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Monos;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active
{
    public class LevelCompletedState : ISceneState
    {
        private readonly LevelCompletedWindow _lcWindow;

        public LevelCompletedState(LevelCompletedWindow lcWindow)
        {
            _lcWindow = lcWindow;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _lcWindow.OpenAwait();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _lcWindow.CloseAwait();
        }
    }
}