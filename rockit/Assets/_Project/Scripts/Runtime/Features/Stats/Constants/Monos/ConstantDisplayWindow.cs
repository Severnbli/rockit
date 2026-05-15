using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Shared.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Shared.Monos;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Monos
{
    public class ConstantDisplayWindow : MonoBaseWindow<BaseWindowConfig>
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _infoText;
        [SerializeField] private Button _improveButton;
        
        public TextMeshProUGUI NameText => _nameText;
        public TextMeshProUGUI InfoText => _infoText;
        public Button ImproveButton => _improveButton;
    }
}