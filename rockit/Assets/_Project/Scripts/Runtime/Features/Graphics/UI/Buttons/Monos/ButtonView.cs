using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Monos
{
    public class ButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        public Button Button => _button;
    }
}