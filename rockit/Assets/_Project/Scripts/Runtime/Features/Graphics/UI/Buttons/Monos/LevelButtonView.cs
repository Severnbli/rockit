using TMPro;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Monos
{
    public class LevelButtonView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _idText;
        [SerializeField] private GameObject _starsContainer;
        
        public TextMeshProUGUI IdText => _idText;
        public GameObject StarsContainer => _starsContainer;
    }
}