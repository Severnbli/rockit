using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Monos
{
    public class MonoFadeWindow : MonoBaseWindow
    {
        [SerializeField] private Image _fade;
        
        public Image Fade => _fade;
    }
}