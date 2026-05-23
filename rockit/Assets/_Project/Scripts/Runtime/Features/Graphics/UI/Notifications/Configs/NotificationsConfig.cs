using _Project.Scripts.Modules.Zenject;
using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Configs
{
    public sealed class NotificationsConfig : ScriptableObjectAutoInstaller<NotificationsConfig>
    {
        [SerializeField] private GameObject _monoNotificationPrefab;
        [SerializeField] private TweenPipeline _center;
        
        public GameObject MonoNotificationPrefab => _monoNotificationPrefab;
        public TweenPipeline Center => _center;
    }
}