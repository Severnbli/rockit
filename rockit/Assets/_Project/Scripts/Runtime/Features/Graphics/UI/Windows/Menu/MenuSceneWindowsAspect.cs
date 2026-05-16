using _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Tags;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Menu.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Menu
{
    public sealed class MenuSceneWindowsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<LevelSelectionTag> LevelSelectionTagPool;
        public readonly ProtoPool<MenuTag> MenuTagPool;
        public readonly ProtoPool<CollectionTag> CollectionTagPool;
        public readonly ProtoIt ClickedLevelSelections = new (It.Inc<ClickedTag, LevelSelectionTag>());
        public readonly ProtoIt ClickedMenus = new (It.Inc<ClickedTag, MenuTag>());
        public readonly ProtoIt ClickedCollections = new (It.Inc<ClickedTag, CollectionTag>());
    }
}