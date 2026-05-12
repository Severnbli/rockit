using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Tools.Player;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Project
{
    public class SwitchSceneState : IProjectState
    {
        private readonly SceneSwitcherService _ssService;
        private readonly ISceneSwitcher _sSwitcher;
        private readonly IMusicPlayer _mPlayer;
        private readonly MusicConfig _mConfig;

        public SwitchSceneState(SceneSwitcherService ssService, ISceneSwitcher sSwitcher, IMusicPlayer mPlayer,
            MusicConfig mConfig)
        {
            _ssService = ssService;
            _sSwitcher = sSwitcher;
            _mPlayer = mPlayer;
            _mConfig = mConfig;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            _mPlayer.Play(_mConfig.Loading, false);
            await _sSwitcher.SwitchScene(_ssService.Target);
            await UniTask.NextFrame();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            await UniTask.NextFrame();
        }
    }
}