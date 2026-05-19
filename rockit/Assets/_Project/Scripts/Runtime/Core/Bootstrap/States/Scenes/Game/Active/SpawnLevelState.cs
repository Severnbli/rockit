using _Project.Scripts.Runtime.Core.Bootstrap.States.Project;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Shared.Utils.Features.World;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active
{
    public class SpawnLevelState : ISceneState
    {
        private readonly RequestsAspect _rAspect;

        public SpawnLevelState(RequestsAspect rAspect)
        {
            _rAspect = rAspect;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            LevelsUtils.CreateSpawnLevelToLoadRequest(_rAspect);
            
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            stateMachine.ChangeState<GameState>().Forget();
#else
            stateMachine.ChangeState<ControlsState>().Forget();
#endif
            await UniTask.NextFrame();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await UniTask.NextFrame();
        }
    }
}