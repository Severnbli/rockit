using _Project.Scripts.Runtime.Features.Input.Types;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.World.Levels.Monos
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private GameObject _psPosition;
        [SerializeField] private PlatformsInputProfile _piProfile;
        
        public GameObject PsPosition => _psPosition;
        public PlatformsInputProfile PiProfile => _piProfile;
    }
}