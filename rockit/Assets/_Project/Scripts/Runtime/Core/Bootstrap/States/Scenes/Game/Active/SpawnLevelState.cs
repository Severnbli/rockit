using _Project.Scripts.Runtime.Features.World.Levels.Types;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active
{
    public class SpawnLevelState : IPostControlsState
    {
        private readonly LevelFactory _lFactory;

        public SpawnLevelState(LevelFactory lFactory)
        {
            _lFactory = lFactory;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            _lFactory.Create();
            stateMachine.ChangeState<GameState>().Forget();
            await UniTask.NextFrame();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await UniTask.NextFrame();
        }
    }
}