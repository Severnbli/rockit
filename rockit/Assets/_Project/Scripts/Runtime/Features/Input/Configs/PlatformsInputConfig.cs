using _Project.Scripts.Modules.Zenject;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Scripts.Runtime.Features.Input.Configs
{
    public sealed class PlatformsInputConfig : ScriptableObjectAutoInstaller<PlatformsInputConfig>
    {
        [SerializeField] private InputActionReference _position;
        [SerializeField] private InputActionReference _rotation;
        [SerializeField] private InputActionReference _scale;
        
        public InputAction Position => _position?.action;
        public InputAction Rotation => _rotation?.action;
        public InputAction Scale => _scale?.action;
    }
}