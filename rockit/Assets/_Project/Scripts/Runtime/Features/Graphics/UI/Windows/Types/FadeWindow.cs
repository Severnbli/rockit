using System.Threading;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Monos;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics.Animations;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Types
{
    public class FadeWindow<TWindow, TConfig> : BaseWindow<TWindow, TConfig>
        where TWindow : MonoFadeWindow 
        where TConfig : FadeWindowConfig<TConfig>
    {
        private readonly MonoFadeWindow _mfWindow;
        private readonly FadeWindowConfig<TConfig> _fwConfig;
        
        public FadeWindow(TWindow window, FadeWindowConfig<TConfig> fwConfig, CancellationToken ct) : 
            base(window, fwConfig, ct)
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
            await _mfWindow.Fade.FadeTween(_fwConfig.FadeOpen).ToUniTask(cancellationToken: Ct);
        }

        protected virtual async UniTask PlayFadeCloseAnimation()
        {
            await _mfWindow.Fade.FadeTween(_fwConfig.FadeClose).ToUniTask(cancellationToken: Ct);
        }
    }
}