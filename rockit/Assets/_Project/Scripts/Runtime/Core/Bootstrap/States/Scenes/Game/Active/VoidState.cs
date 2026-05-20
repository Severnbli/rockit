using System;
using System.Threading;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Monos;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active
{
    public class VoidState : ISceneState
    {
        private readonly VoidWindow _vWindow;
        private readonly VoidWindowConfig _vwConfig;
        private readonly CancellationToken _ct;

        public VoidState(VoidWindow vWindow, VoidWindowConfig vwConfig, CancellationToken ct)
        {
            _vWindow = vWindow;
            _vwConfig = vwConfig;
            _ct = ct;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _vWindow.OpenAwait();
            await UniTask.Delay(TimeSpan.FromSeconds(_vwConfig.Duration), cancellationToken: _ct);
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _vWindow.CloseAwait();
        }
    }
}