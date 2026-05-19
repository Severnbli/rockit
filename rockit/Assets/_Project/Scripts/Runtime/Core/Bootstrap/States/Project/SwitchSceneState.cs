using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Tools.Player;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Project.Monos;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Project
{
    public class SwitchSceneState : IProjectState
    {
        private readonly SceneSwitcherService _ssService;
        private readonly ISceneSwitcher _sSwitcher;
        private readonly IMusicPlayer _mPlayer;
        private readonly MusicConfig _mConfig;
        private readonly LoadingWindow _lWindow;

        public SwitchSceneState(SceneSwitcherService ssService, ISceneSwitcher sSwitcher, IMusicPlayer mPlayer,
            MusicConfig mConfig, LoadingWindow lWindow)
        {
            _ssService = ssService;
            _sSwitcher = sSwitcher;
            _mPlayer = mPlayer;
            _mConfig = mConfig;
            _lWindow = lWindow;
        }

        public async UniTask OnEnter(IStateMachine stateMachine)
        {
            _mPlayer.Play(_mConfig.Loading, false);
            await _lWindow.OpenAwait();
            await _sSwitcher.SwitchScene(_ssService.Target);
            await UniTask.NextFrame();
        }

        public async UniTask OnLeave(IStateMachine stateMachine)
        {
            _mPlayer.Stop();
            await _lWindow.CloseAwait();
            await UniTask.NextFrame();
        }
    }
}