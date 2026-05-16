using _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Tags;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Menu;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Menu.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Shared
{
    public sealed class WindowsSharedAspect : ProtoAspectInject
    {
        public readonly MenuSceneWindowsAspect MenuSceneWindowsAspect;
        
        public readonly ProtoPool<SettingsTag> SettingsTagPool;
        public readonly ProtoIt ClickedSettings = new (It.Inc<ClickedTag, SettingsTag>());
    }
}