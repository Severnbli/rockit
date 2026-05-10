using TMPro;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Monos
{
    public class LevelButtonView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _idText;
        
        public TextMeshProUGUI IdText => _idText;
    }
}