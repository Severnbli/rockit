using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Tags;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Tags;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons;
using _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Tags;
using _Project.Scripts.Runtime.Features.Graphics.UI.Text.Shared;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Shared;
using _Project.Scripts.Runtime.Features.World.Levels.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared
{
    public sealed class UISharedAspect : ProtoAspectInject
    {
        public readonly ButtonsAspect ButtonsAspect;
        public readonly TextSharedAspect TextSharedAspect;
        public readonly WindowsSharedAspect WindowsSharedAspect;
        
        public readonly ProtoPool<ClickedTag> ClickedTagPool;
        public readonly ProtoPool<ActiveUIElementTag> ActiveUIElementTagPool;
        public readonly ProtoIt ClickedTags = new (It.Inc<ClickedTag>());
        public readonly ProtoIt ClickedCloseAppItems = new (It.Inc<CloseAppTag, ClickedTag>());
        public readonly ProtoIt ClickedOpenableItems = new (It.Inc<OpenerTag, OpenableClosableComponent, ClickedTag>());
        public readonly ProtoIt ClickedClosableItems = new (It.Inc<CloserTag, OpenableClosableComponent, ClickedTag>());
        public readonly ProtoIt ClickedLevelItemSceneLoaders = new (It.Inc<ClickedTag, LevelItemComponent, SceneLoaderTag>());
        public readonly ProtoIt ClickedMenuSceneLoaders = new (It.Inc<ClickedTag, MenuSceneTag, SceneLoaderTag>());
        public readonly ProtoIt ClickedGameSceneLoaders = new (It.Inc<ClickedTag, GameSceneTag, SceneLoaderTag>());
        public readonly ProtoIt ActiveUIElements = new (It.Inc<ActiveUIElementTag>());
        public readonly ProtoItExc ClickedInactiveUIElements = new (It.Inc<ClickedTag>(),It.Exc<ActiveUIElementTag>());
    }
}