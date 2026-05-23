using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Monos
{
    public class NotificationsArea : MonoBehaviour
    {
        [SerializeField] private GameObject _fallbackContainer;
        [SerializeField] private GameObject _centerContainer;
        
        public GameObject FallbackContainer => _fallbackContainer;
        public GameObject CenterContainer => _centerContainer;
    }
}