using _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline.Core;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs
{
    public class FadeWindowConfig<T> : BaseWindowConfig<T> where T : FadeWindowConfig<T>
    {
        [SerializeField] private TweenPipeline _fadeOpen;
        [SerializeField] private TweenPipeline _fadeClose;
        
        public TweenPipeline FadeOpen => _fadeOpen;
        public TweenPipeline FadeClose => _fadeClose;
    }
}