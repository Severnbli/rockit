using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Project
{
    public class SwitchSceneState : IProjectState
    {
        private readonly SceneSwitcherService _ssService;
        private readonly ISceneSwitcher _sSwitcher;

        public SwitchSceneState(SceneSwitcherService ssService, ISceneSwitcher sSwitcher)
        {
            _ssService = ssService;
            _sSwitcher = sSwitcher;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _sSwitcher.SwitchScene(_ssService.Target);
            await UniTask.CompletedTask;
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await UniTask.CompletedTask;
        }
    }
}