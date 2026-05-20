using _Project.Scripts.Runtime.Features.Input.Types;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.World.Levels.Monos
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private GameObject _psPosition;
        [SerializeField] private PlatformsInputProfile _piProfile;
        [SerializeField] private Collider2D _cameraBounds;
        
        public GameObject PsPosition => _psPosition;
        public PlatformsInputProfile PiProfile => _piProfile;
        public Collider2D CameraBounds => _cameraBounds;
    }
}