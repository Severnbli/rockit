using _Project.Scripts.Runtime.Features.Input.Types;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.World.Levels.Monos
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private GameObject _playerSpawnPosition;
        [SerializeField] private PlatformsInputProfile _piProfile;
        
        public PlatformsInputProfile PiProfile => _piProfile;
    }
}