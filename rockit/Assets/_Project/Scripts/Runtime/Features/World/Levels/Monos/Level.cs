using UnityEngine;

namespace _Project.Scripts.Runtime.Features.World.Levels.Monos
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private GameObject _psPosition;
        [SerializeField] private Collider2D _cameraBounds;
        
        public GameObject PsPosition => _psPosition;
        public Collider2D CameraBounds => _cameraBounds;
    }
}