using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Project
{
    public class ProjectSetupState : IProjectSetupState
    {
        private readonly LocalizationService _lService;

        public ProjectSetupState(LocalizationService lService)
        {
            _lService = lService;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _lService.LoadLangData();
            stateMachine.ChangeState<ISceneSetupState>().Forget();
            await UniTask.NextFrame();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await UniTask.NextFrame();
        }
    }
}