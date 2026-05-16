using _Project.Scripts.Runtime.Core.Bootstrap.States;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes;
using Cysharp.Threading.Tasks;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Shared.Systems
{
    public sealed class SwitchToSettingsStateOnClickedSettingsSystem : IProtoRunSystem
    {
        [DI] private readonly SharedSceneWindowsAspect _sswAspect;
        private readonly IStateMachine _sMachine;

        public SwitchToSettingsStateOnClickedSettingsSystem(IStateMachine sMachine)
        {
            _sMachine = sMachine;
        }

        public void Run()
        {
            if (_sswAspect.ClickedSettings.IsEmptySlow()) return;
            _sMachine.ChangeState<ISettingsState>().Forget();
        }
    }
}