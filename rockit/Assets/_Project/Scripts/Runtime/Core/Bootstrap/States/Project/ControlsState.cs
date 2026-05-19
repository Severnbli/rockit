using System;
using System.Threading;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Project.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Project.Monos;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Project
{
    public class ControlsState : IProjectState
    {
        private readonly ControlsWindow _cWindow;
        private readonly ControlsWindowConfig _cwConfig;
        private readonly CancellationToken _ct;

        public ControlsState(ControlsWindow cWindow, ControlsWindowConfig cwConfig, CancellationToken ct)
        {
            _cWindow = cWindow;
            _cwConfig = cwConfig;
            _ct = ct;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _cWindow.OpenAwait();
            await UniTask.Delay(TimeSpan.FromSeconds(_cwConfig.Duration), cancellationToken: _ct);
            stateMachine.ChangeState<IPostControlsState>().Forget();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _cWindow.CloseAwait();
        }
    }
}