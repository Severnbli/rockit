using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools;
using _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Monos;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Types
{
    public abstract class BaseNotificationPool<TItem, TSpawnSettings, TDespawnSettings> : 
        BasePrefabPool<TItem, TSpawnSettings, TDespawnSettings>
        where TItem : Component
        where TSpawnSettings : struct
        where TDespawnSettings : struct
    {
        protected readonly NotificationsArea NArea;
        protected readonly NotificationsConfig NConfig;
        
        protected BaseNotificationPool(ProtoWorld world, NotificationsArea nArea, NotificationsConfig nConfig) 
            : base(world)
        {
            NArea = nArea;
            NConfig = nConfig;
        }

        protected override void PostDespawn(TItem instance, TDespawnSettings settings = default)
        {
            base.PostDespawn(instance, settings);
            
            instance.gameObject.transform.SetParent(NArea.transform);
        }
    }
}