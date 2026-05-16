using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Shared.Monos;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Shared.Active
{
    public class SettingsState : ISettingsState
    {
        private readonly SettingsWindow _sWindow;

        public SettingsState(SettingsWindow sWindow)
        {
            _sWindow = sWindow;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _sWindow.OpenAwait();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _sWindow.CloseAwait();
        }
    }
}