using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Tools.Player;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active
{
    public class GameSceneSetupState : ISceneSetupState
    {
        private readonly IMusicPlayer _mPlayer;
        private readonly MusicConfig _mConfig;

        public GameSceneSetupState(IMusicPlayer mPlayer, MusicConfig mConfig)
        {
            _mPlayer = mPlayer;
            _mConfig = mConfig;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            _mPlayer.Play(_mConfig.Game, true);
            stateMachine.ChangeState<SpawnLevelState>().Forget();
            await UniTask.NextFrame();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await UniTask.NextFrame();
        }
    }
}