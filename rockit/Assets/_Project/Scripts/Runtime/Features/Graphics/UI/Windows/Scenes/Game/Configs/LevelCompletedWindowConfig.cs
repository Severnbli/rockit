using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Shared.Configs;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Configs
{
    public class LevelCompletedWindowConfig : FadeWindowConfig
    {
        [SerializeField] private TweenPipeline _starsAppear;
        [SerializeField] private TweenPipeline _coinsAppear;
        [SerializeField] private TweenPipeline _controlsAppear;
        [SerializeField] private TweenPipeline _controlsDisappear;
        
        public TweenPipeline StarsAppear => _starsAppear;
        public TweenPipeline CoinsAppear => _coinsAppear;
        public TweenPipeline ControlsAppear => _controlsAppear;
        public TweenPipeline ControlsDisappear => _controlsDisappear;
    }
}