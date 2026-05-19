using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Shared.Utils.Features.Input;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active
{
    public class GameState : ISceneState
    {
        private readonly RequestsAspect _rAspect;

        public GameState(RequestsAspect rAspect)
        {
            _rAspect = rAspect;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            PlayerInputUtils.CreateEnableRequest(_rAspect);
            PlatformsInputUtils.CreateEnableRequest(_rAspect);
            await UniTask.NextFrame();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            PlayerInputUtils.CreateDisableRequest(_rAspect);
            PlatformsInputUtils.CreateDisableRequest(_rAspect);
            await UniTask.NextFrame();
        }
    }
}