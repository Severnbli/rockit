using System.Threading;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline.Core;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Monos;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Types
{
    public class FadeWindow<TWindow, TConfig> : BaseWindow<TWindow, TConfig>
        where TWindow : MonoFadeWindow 
        where TConfig : FadeWindowConfig<TConfig>
    {
        private readonly MonoFadeWindow _mfWindow;
        private readonly FadeWindowConfig<TConfig> _fwConfig;
        
        public FadeWindow(TWindow window, FadeWindowConfig<TConfig> fwConfig, CancellationToken ct, 
            TweenPipelineRunner tpRunner) : base(window, fwConfig, ct, tpRunner)
        {
            _mfWindow = window;
            _fwConfig = fwConfig;
        }

        protected override UniTask PlayOpenAnimation()
        {
            return UniTask.WhenAll(
                base.PlayOpenAnimation(),
                PlayFadeOpenAnimation()
            );
        }

        protected override UniTask PlayCloseAnimation()
        {
            return UniTask.WhenAll(
                base.PlayCloseAnimation(),
                PlayFadeCloseAnimation()
            );
        }

        protected virtual async UniTask PlayFadeOpenAnimation()
        {
            await TpRunner.Run(_fwConfig.FadeOpen, _mfWindow.Fade, true);
        }

        protected virtual async UniTask PlayFadeCloseAnimation()
        {
            await TpRunner.Run(_fwConfig.FadeClose, _mfWindow.Fade, true);
        }
    }
}