using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons;
using _Project.Scripts.Runtime.Features.Graphics.UI.Text.Shared;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared
{
    public sealed class UISharedAspect : ProtoAspectInject
    {
        public readonly ButtonsAspect ButtonsAspect;
        public readonly TextSharedAspect TextSharedAspect;
    }
}