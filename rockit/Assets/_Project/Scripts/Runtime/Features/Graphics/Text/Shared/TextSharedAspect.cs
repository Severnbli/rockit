using _Project.Scripts.Runtime.Features.Graphics.Text.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Text.Shared
{
    public sealed class TextSharedAspect : ProtoAspectInject
    {
        public readonly ProtoPool<TextUiComponent> TextUiComponentPool;
        public readonly ProtoIt TextUis = new (It.Inc<TextUiComponent>());
    }
}