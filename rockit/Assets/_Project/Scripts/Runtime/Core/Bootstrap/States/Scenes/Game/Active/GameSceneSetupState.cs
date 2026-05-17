using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Shared.Active;
using _Project.Scripts.Runtime.Core.Engine;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Tools.Player;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active
{
    public class GameSceneSetupState : SceneSetupState
    {
        private readonly IMusicPlayer _mPlayer;
        private readonly MusicConfig _mConfig;

        public GameSceneSetupState(IEngine engine, IMusicPlayer mPlayer, MusicConfig mConfig) : base(engine)
        {
            _mPlayer = mPlayer;
            _mConfig = mConfig;
        }

        public override async UniTask OnEnter(IStateMachine stateMachine)
        {
            await base.OnEnter(stateMachine);
            
            _mPlayer.Play(_mConfig.Game, true);
            stateMachine.ChangeState<SpawnLevelState>().Forget();
        }

        public override async UniTask OnLeave(IStateMachine stateMachine)
        {
            await base.OnLeave(stateMachine);
        }
    }
}