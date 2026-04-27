using TMPro;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Shared.Monos
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _idText;
        
        public TextMeshProUGUI IdText => _idText;
    }
}