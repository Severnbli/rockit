using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core;
using _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Monos;
using _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Types;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Tools
{
    public class Notifier : INotifier
    {
        protected readonly NotificationsConfig NConfig;
        protected readonly NotificationsArea NArea;
        protected readonly MonoNotificationPool MnPool;
        protected readonly ITweenPipelineRunner TpRunner;

        public Notifier(NotificationsConfig nConfig, NotificationsArea nArea, MonoNotificationPool mnPool, 
            ITweenPipelineRunner tpRunner)
        {
            NConfig = nConfig;
            NArea = nArea;
            MnPool = mnPool;
            TpRunner = tpRunner;
        }

        public async UniTask ShowCenterNotification(string text)
        {
            var settings = new MonoNotificationPoolSpawnSettings
            {
                Text = text
            };
            var notification = MnPool.Spawn(NArea.CenterContainer.transform, settings);
            
            await TpRunner.Run(NConfig.Center, notification.gameObject);
            
            MnPool.Despawn(notification);
        }
    }
}