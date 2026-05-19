using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Shared.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Shared.Monos;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Project.Monos
{
    public class LoadingWindow : MonoFadeWindow<FadeWindowConfig>
    {
        [SerializeField] private TextMeshProUGUI _loadingText;
        
        public TextMeshProUGUI LoadingText => _loadingText;
    }
}