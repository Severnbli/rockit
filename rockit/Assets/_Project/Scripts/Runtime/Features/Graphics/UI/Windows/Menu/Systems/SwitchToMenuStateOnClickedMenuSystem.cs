using _Project.Scripts.Runtime.Core.Bootstrap.States;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active;
using Cysharp.Threading.Tasks;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Menu.Systems
{
    public sealed class SwitchToMenuStateOnClickedMenuSystem : IProtoRunSystem
    {
        [DI] private readonly MenuSceneWindowsAspect _mswAspect;
        private readonly IStateMachine _sMachine;

        public SwitchToMenuStateOnClickedMenuSystem(IStateMachine sMachine)
        {
            _sMachine = sMachine;
        }

        public void Run()
        {
            if (_mswAspect.ClickedMenus.IsEmptySlow()) return;
            _sMachine.ChangeState<MenuState>().Forget();
        }
    }
}