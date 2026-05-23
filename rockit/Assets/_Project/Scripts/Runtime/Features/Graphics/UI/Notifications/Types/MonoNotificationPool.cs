using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools;
using _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Monos;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Types
{
    public class MonoNotificationPool : BasePrefabPool<MonoNotification, MonoNotificationPoolSpawnSettings, MonoNotificationPoolDespawnSettings>
    {
        protected readonly NotificationsConfig NConfig;
        
        public MonoNotificationPool(ProtoWorld world, NotificationsConfig nConfig) : base(world)
        {
            NConfig = nConfig;
        }

        protected override void PostSpawn(MonoNotification instance, Transform at = null, MonoNotificationPoolSpawnSettings settings = default)
        {
            base.PostSpawn(instance, at, settings);

            instance.Text.text = settings.Text;
        }

        protected override void PostDespawn(MonoNotification instance, MonoNotificationPoolDespawnSettings settings = default)
        {
            base.PostDespawn(instance, settings);
            
            instance.Text.text = string.Empty;
        }

        protected override GameObject GetPrefab() => NConfig.MonoNotificationPrefab;
    }

    public struct MonoNotificationPoolSpawnSettings
    {
        public string Text;
    }

    public struct MonoNotificationPoolDespawnSettings
    {
        
    }
}