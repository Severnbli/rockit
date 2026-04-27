using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Shared;
using _Project.Scripts.Runtime.Features.Graphics.UI.Text.Shared;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared
{
    public sealed class UISharedAspect : ProtoAspectInject
    {
        public readonly ButtonsSharedAspect ButtonsSharedAspect;
        public readonly TextSharedAspect TextSharedAspect;
    }
}