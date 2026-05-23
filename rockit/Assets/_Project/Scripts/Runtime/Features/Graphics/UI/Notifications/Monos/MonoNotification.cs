using TMPro;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Monos
{
    public class MonoNotification : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        public TextMeshProUGUI Text => _text;
    }
}