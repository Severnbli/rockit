using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils.Features.Graphics
{
    public static class NotificationsUtils
    {
        public static ProtoEntity CreateShowCenterNotificationRequest(RequestsAspect aspect,
            ShowCenterNotificationRequest prepared)
        {
            return aspect.CreateRequest(
                aspect.UIRequestsAspect.NotificationsRequestsAspect.ShowCenterNotificationRequestPool,
                prepared: prepared);
        }
    }
}