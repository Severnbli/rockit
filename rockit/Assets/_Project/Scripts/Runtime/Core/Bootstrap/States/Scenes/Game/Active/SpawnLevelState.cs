using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active
{
    public class SpawnLevelState : ISceneState
    {
        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            await UniTask.NextFrame();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await UniTask.NextFrame();
        }
    }
}