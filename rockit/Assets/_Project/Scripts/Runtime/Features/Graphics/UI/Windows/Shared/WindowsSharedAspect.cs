using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Menu;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Shared;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Shared
{
    public sealed class WindowsSharedAspect : ProtoAspectInject
    {
        public readonly MenuSceneWindowsAspect MenuSceneWindowsAspect;
        public readonly SharedSceneWindowsAspect SharedSceneWindowsAspect;
    }
}