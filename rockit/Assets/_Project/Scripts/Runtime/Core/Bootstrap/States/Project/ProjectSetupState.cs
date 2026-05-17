using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes;
using _Project.Scripts.Runtime.Core.Engine;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Project
{
    public class ProjectSetupState : IProjectSetupState
    {
        private readonly LocalizationService _lService;
        private readonly IEngine _engine;

        public ProjectSetupState(LocalizationService lService, IEngine engine)
        {
            _lService = lService;
            _engine = engine;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await _lService.LoadLangData();
            
            _engine.Init();
            
            stateMachine.ChangeState<ISceneSetupState>().Forget();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await UniTask.NextFrame();
        }
    }
}