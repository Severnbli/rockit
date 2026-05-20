using _Project.Scripts.Runtime.Core.Bootstrap.States;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active;
using Cysharp.Threading.Tasks;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Systems
{
    public sealed class SwitchToPauseStateOnClickedPauseSystem : IProtoRunSystem
    {
        [DI] private readonly GameSceneWindowsAspect _gswAspect;
        private readonly IStateMachine _sMachine;

        public SwitchToPauseStateOnClickedPauseSystem(IStateMachine sMachine)
        {
            _sMachine = sMachine;
        }

        public void Run()
        {
            if (_gswAspect.ClickedPauses.IsEmptySlow()) return;
            _sMachine.ChangeState<PauseState>().Forget();
        }
    }
}