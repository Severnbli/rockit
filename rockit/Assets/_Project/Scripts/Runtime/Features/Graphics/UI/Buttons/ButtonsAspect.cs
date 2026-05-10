using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Tags;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons
{
    public sealed class ButtonsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<ButtonComponent> ButtonComponentPool;
        public readonly ProtoPool<LevelButtonComponent> LevelButtonComponentPool;
        public readonly ProtoIt Buttons = new (It.Inc<ButtonComponent>());
        public readonly ProtoIt CloseAppButtons = new (It.Inc<ButtonComponent, CloseAppTag>());
        public readonly ProtoIt LevelButtons = new (It.Inc<ButtonComponent, LevelButtonComponent>());
    }
}