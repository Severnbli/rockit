using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Shared.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Shared.Monos;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Runtime.Features.Input.Monos
{
    public class PlatformsInputWindow : MonoBaseWindow<BaseWindowConfig>
    {
        [SerializeField] private Button _positionButton;
        
        public Button PositionButton => _positionButton;
    }
}