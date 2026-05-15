using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Stats.Constants.Services;
using _Project.Scripts.Runtime.Shared.Utils.Features.Stats;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active
{
    public class CollectionState : ISceneState
    {
        private readonly ConstantDisplayWindowService _cdwService;
        private readonly RequestsAspect _rAspect;

        public CollectionState(ConstantDisplayWindowService cdwService, RequestsAspect rAspect)
        {
            _cdwService = cdwService;
            _rAspect = rAspect;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            _cdwService.Active = true;
            ConstantsUtils.CreateShowConstantDisplayWindowRequest(_rAspect);
            await UniTask.NextFrame();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            _cdwService.Active = false;
            await UniTask.NextFrame();
        }
    }
}