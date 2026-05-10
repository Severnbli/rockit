using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs
{
    public class FadeWindowConfig : BaseWindowConfig
    {
        [SerializeField] private TweenPipeline _fadeOpen;
        [SerializeField] private TweenPipeline _fadeClose;
        
        public TweenPipeline FadeOpen => _fadeOpen;
        public TweenPipeline FadeClose => _fadeClose;
    }
}