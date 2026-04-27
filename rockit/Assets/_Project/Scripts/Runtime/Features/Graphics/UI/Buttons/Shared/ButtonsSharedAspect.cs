using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Tags;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Shared
{
    public sealed class ButtonsSharedAspect : ProtoAspectInject
    {
        public readonly ProtoPool<ButtonComponent> ButtonComponentPool;
        public readonly ProtoPool<LevelButtonComponent> LevelButtonComponentPool;
        public readonly ProtoIt Buttons = new (It.Inc<ButtonComponent>());
        public readonly ProtoIt CloseAppButtons = new (It.Inc<ButtonComponent, CloseAppTag>());
        public readonly ProtoIt LevelButtons = new (It.Inc<ButtonComponent, LevelButtonComponent>());
    }
}