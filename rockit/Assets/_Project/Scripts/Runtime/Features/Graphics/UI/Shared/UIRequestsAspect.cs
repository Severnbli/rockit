using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons;
using _Project.Scripts.Runtime.Features.Graphics.UI.Notifications;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared
{
    public sealed class UIRequestsAspect : ProtoAspectInject
    {
        public readonly ButtonsRequestsAspect ButtonsRequestsAspect;
        public readonly NotificationsRequestsAspect NotificationsRequestsAspect;
    }
}