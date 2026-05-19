using _Project.Scripts.Runtime.Core.Bootstrap.States.Project;
using _Project.Scripts.Runtime.Features.World.Levels.Types;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active
{
    public class SpawnLevelState : ISceneState
    {
        private readonly LevelFactory _lFactory;

        public SpawnLevelState(LevelFactory lFactory)
        {
            _lFactory = lFactory;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            _lFactory.Create();
            
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