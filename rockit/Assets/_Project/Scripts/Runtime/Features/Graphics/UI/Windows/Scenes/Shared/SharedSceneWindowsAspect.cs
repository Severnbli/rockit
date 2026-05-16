using _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Tags;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Shared.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Shared
{
    public sealed class SharedSceneWindowsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<SettingsTag> SettingsTagPool;
        public readonly ProtoIt ClickedSettings = new (It.Inc<ClickedTag, SettingsTag>());
    }
}