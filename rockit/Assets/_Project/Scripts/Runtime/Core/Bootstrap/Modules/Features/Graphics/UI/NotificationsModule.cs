using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Systems;
using _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Tools;
using _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Types;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI
{
    public sealed class NotificationsModule : BaseModule<NotificationsModule>
    {
        public NotificationsModule(IDomain domain) : base(domain)
        {
        }

        protected override void RegisterBindings()
        {
            base.RegisterBindings();

            Container.Bind<MonoNotificationPool>().ToSelf().AsSingle();
            Container.Bind<INotifier>().To<Notifier>().AsSingle();
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<ShowCenterNotificationOnShowCenterNotificationRequest>();
        }
    }
}