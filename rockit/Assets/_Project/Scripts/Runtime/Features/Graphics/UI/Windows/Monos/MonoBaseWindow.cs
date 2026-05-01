using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Monos
{
    public class MonoBaseWindow : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        
        public GameObject Body => _body;
    }
}