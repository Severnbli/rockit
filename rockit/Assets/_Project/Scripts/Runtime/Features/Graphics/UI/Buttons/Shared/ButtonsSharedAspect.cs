using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Shared.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Shared
{
    public sealed class ButtonsSharedAspect : ProtoAspectInject
    {
        public readonly ProtoPool<CloseAppButtonTag> CloseAppButtonTagPool;
        public readonly ProtoIt CloseAppButtonTags = new (It.Inc<CloseAppButtonTag>());
    }
}