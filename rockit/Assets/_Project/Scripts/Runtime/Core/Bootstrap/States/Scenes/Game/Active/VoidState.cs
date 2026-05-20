using System;
using System.Threading;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Monos;
using _Project.Scripts.Runtime.Shared.Utils.Features;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active
{
    public class VoidState : ISceneState
    {
        private readonly VoidWindow _vWindow;
        private readonly VoidWindowConfig _vwConfig;
        private readonly CancellationToken _ct;
        private readonly RequestsAspect _rAspect;

        public VoidState(VoidWindow vWindow, VoidWindowConfig vwConfig, CancellationToken ct, RequestsAspect rAspect)
        {
            _vWindow = vWindow;
            _vwConfig = vwConfig;
            _ct = ct;
            _rAspect = rAspect;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _vWindow.OpenAwait();
            
            PlayerUtils.CreatePlacePlayerToLastCheckpointRequest(_rAspect);
            await UniTask.Delay(TimeSpan.FromSeconds(_vwConfig.Duration), cancellationToken: _ct);

            stateMachine.ChangeState<GameState>().Forget();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await _vWindow.CloseAwait();
        }
    }
}