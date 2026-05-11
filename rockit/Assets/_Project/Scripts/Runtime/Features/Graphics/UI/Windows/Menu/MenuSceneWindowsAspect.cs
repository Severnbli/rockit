using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Menu.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Menu
{
    public sealed class MenuSceneWindowsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<LevelSelectionTag> LevelSelectionTagPool;
    }
}