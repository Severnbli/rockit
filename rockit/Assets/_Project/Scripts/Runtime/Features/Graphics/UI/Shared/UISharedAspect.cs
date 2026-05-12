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
        public readonly ProtoIt ClickedTags = new (It.Inc<ClickedTag>());
        public readonly ProtoIt ClickedCloseAppItems = new (It.Inc<CloseAppTag, ClickedTag>());
        public readonly ProtoIt ClickedOpenableItems = new (It.Inc<OpenerTag, OpenableClosableComponent, ClickedTag>());
        public readonly ProtoIt ClickedClosableItems = new (It.Inc<CloserTag, OpenableClosableComponent, ClickedTag>());
        public readonly ProtoIt ClickedLevelItemOpeners = new (It.Inc<ClickedTag, LevelItemComponent, OpenerTag>());
        public readonly ProtoIt ClickedMenuSceneOpeners = new (It.Inc<ClickedTag, MenuSceneTag, OpenerTag>());
    }
}