using _Project.Scripts.Runtime.Core.Bootstrap.States;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active;
using Cysharp.Threading.Tasks;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Menu.Systems
{
    public sealed class SwitchToLevelSelectionStateOnClickedLevelSelectionSystem : IProtoRunSystem
    {
        [DI] private readonly MenuSceneWindowsAspect _mswAspect;
        private readonly IStateMachine _sMachine;

        public SwitchToLevelSelectionStateOnClickedLevelSelectionSystem(IStateMachine sMachine)
        {
            _sMachine = sMachine;
        }

        public void Run()
        {
            if (_mswAspect.ClickedLevelSelections.IsEmptySlow()) return;
            _sMachine.ChangeState<LevelSelectionState>().Forget();
        }
    }
}