using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Tools.Player;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active
{
    public class MenuSceneSetupState : ISceneSetupState
    {
        private readonly IMusicPlayer _mPlayer;
        private readonly MusicConfig _mConfig;

        public MenuSceneSetupState(IMusicPlayer mPlayer, MusicConfig mConfig)
        {
            _mPlayer = mPlayer;
            _mConfig = mConfig;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            _mPlayer.Play(_mConfig.Menu, true);
            stateMachine.ChangeState<MenuWindowState>().Forget();
            await UniTask.NextFrame();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await UniTask.NextFrame();
        }
    }
}