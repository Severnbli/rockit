using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Notifications
{
    public sealed class NotificationsRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<ShowCenterNotificationRequest> ShowCenterNotificationRequestPool;
        public readonly ProtoIt ShowCenterNotificationRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, ShowCenterNotificationRequest>());
    }
}