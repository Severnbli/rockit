using System.Threading;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Monos;

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
    }
}