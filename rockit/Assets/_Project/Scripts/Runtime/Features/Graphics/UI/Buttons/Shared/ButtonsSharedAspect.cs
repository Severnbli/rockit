using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Shared.Components;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Shared.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Shared
{
    public sealed class ButtonsSharedAspect : ProtoAspectInject
    {
        public readonly ProtoPool<CloseAppButtonTag> CloseAppButtonTagPool;
        public readonly ProtoPool<ButtonComponent> ButtonComponentPool;
        public readonly ProtoIt CloseAppButtonTags = new (It.Inc<CloseAppButtonTag>());
        public readonly ProtoIt Buttons = new (It.Inc<ButtonComponent>());
        public readonly ProtoIt CloseAppButtons = new (It.Inc<ButtonComponent, CloseAppButtonTag>());
    }
}