using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Types;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs
{
    public class FadeWindowConfig<T> : BaseWindowConfig<T> where T : FadeWindowConfig<T>
    {
        [SerializeField] private FloatTweenSettings _fadeOpen;
        [SerializeField] private FloatTweenSettings _fadeClose;
        
        public FloatTweenSettings FadeOpen => _fadeOpen;
        public FloatTweenSettings FadeClose => _fadeClose;
    }
}