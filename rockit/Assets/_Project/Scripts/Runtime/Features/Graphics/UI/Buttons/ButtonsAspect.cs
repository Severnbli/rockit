using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Tags;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Components;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons
{
    public sealed class ButtonsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<ButtonComponent> ButtonComponentPool;
        public readonly ProtoPool<LevelButtonComponent> LevelButtonComponentPool;
        public readonly ProtoPool<ButtonTriggeredTag> ButtonTriggeredTagPool;
        public readonly ProtoIt Buttons = new (It.Inc<ButtonComponent>());
        public readonly ProtoIt TriggeredCloseAppButtons = new (It.Inc<ButtonComponent, ButtonTriggeredTag, CloseAppTag>());
        public readonly ProtoIt LevelButtons = new (It.Inc<ButtonComponent, LevelButtonComponent>());
        public readonly ProtoIt TriggeredButtons = new (It.Inc<ButtonComponent, ButtonTriggeredTag>());
    }
}