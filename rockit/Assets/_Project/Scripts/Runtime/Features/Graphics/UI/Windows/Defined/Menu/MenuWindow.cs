using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Types;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Defined.Menu
{
    public sealed class MenuWindow : FadeWindow<MonoMenuWindow, MenuWindowConfig>
    {
        public MenuWindow(MonoMenuWindow window, FadeWindowConfig<MenuWindowConfig> fwConfig, TweenPipelineRunner tpRunner) : base(window, fwConfig, tpRunner)
        {
        }
    }
}