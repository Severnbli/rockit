using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Tools;
using Cysharp.Threading.Tasks;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Systems
{
    public sealed class ShowCenterNotificationOnShowCenterNotificationRequest : IProtoRunSystem
    {
        [DIRequests] private readonly NotificationsRequestsAspect _nrAspect;
        private readonly INotifier _notifier;

        public ShowCenterNotificationOnShowCenterNotificationRequest(INotifier notifier)
        {
            _notifier = notifier;
        }

        public void Run()
        {
            foreach (var e in _nrAspect.ShowCenterNotificationRequests)
            {
                ref var scnRequest = ref _nrAspect.ShowCenterNotificationRequestPool.Get(e);
                _notifier.ShowCenterNotification(scnRequest.Text).Forget();
            }
        }
    }
}