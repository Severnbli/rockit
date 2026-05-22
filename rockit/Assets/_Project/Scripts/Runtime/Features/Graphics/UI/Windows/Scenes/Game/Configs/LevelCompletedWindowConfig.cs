using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Shared.Configs;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Configs
{
    public class LevelCompletedWindowConfig : FadeWindowConfig
    {
        [SerializeField] private TweenPipeline _starsAppear;
        [SerializeField] private TweenPipeline _coinsAppear;
        [SerializeField] private TweenPipeline _buttonsOpen;
        [SerializeField] private TweenPipeline _buttonsClose;
        
        public TweenPipeline StarsAppear => _starsAppear;
        public TweenPipeline CoinsAppear => _coinsAppear;
        public TweenPipeline ButtonsOpen => _buttonsOpen;
        public TweenPipeline ButtonsClose => _buttonsClose;
    }
}