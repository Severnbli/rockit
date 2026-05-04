using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Monos
{
    public class MonoFadeWindow : MonoBaseWindow
    {
        [SerializeField] private GameObject _fade;
        
        public GameObject Fade => _fade;
    }
}