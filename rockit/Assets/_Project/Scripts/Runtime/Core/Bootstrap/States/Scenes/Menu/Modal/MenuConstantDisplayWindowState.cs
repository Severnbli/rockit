using _Project.Scripts.Runtime.Features.Stats.Constants.Monos;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Modal
{
    public class MenuConstantDisplayWindowState : ISceneState
    {
        private readonly ConstantDisplayWindow _cdwWindow;

        public MenuConstantDisplayWindowState(ConstantDisplayWindow cdwWindow)
        {
            _cdwWindow = cdwWindow;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _cdwWindow.OpenAwait();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _cdwWindow.CloseAwait();
        }
    }
}