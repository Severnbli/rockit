using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Monos;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Types
{
    public class BaseWindow<TWindow, TConfig> 
        where TWindow : MonoBaseWindow
        where TConfig : BaseWindowConfig<TConfig>
    {
        private MonoBaseWindow _mbWindow;
        private BaseWindowConfig<TConfig> _bwConfig;

        public BaseWindow(TWindow window, BaseWindowConfig<TConfig> bwConfig)
        {
            _mbWindow = window;
            _bwConfig = bwConfig;
        }
    }
}