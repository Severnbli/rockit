using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Shared.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Shared.Monos;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Project.Monos
{
    public class ControlsWindow : MonoBaseWindow<BaseWindowConfig>
    {
        [SerializeField] private TextMeshProUGUI _infoText;
        
        public TextMeshProUGUI InfoText => _infoText;
    }
}