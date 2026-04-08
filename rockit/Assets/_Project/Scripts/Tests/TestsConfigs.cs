using _Project.Scripts.Runtime.Features.Input.Configs;
using UnityEngine;

namespace _Project.Scripts.Tests
{
    public class TestsConfigs : ScriptableObject
    {
        [SerializeField] private PlayerInputConfig _playerInputConfig;
        [SerializeField] private PlatformsInputConfig _platformsInputConfig;
        
        public PlayerInputConfig PlayerInputConfig => _playerInputConfig;
        public PlatformsInputConfig PlatformsInputConfig => _platformsInputConfig;
    }
}