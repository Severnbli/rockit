using _Project.Scripts.Modules.Zenject;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Scripts.Runtime.Features.Input.Configs
{
    public class PlatformsInputConfig : ScriptableObjectAutoInstaller<PlatformsInputConfig>
    {
        [SerializeField] private InputActionReference _position;
        [SerializeField] private InputActionReference _rotation;
        [SerializeField] private InputActionReference _scale;
        
        public InputActionReference Position => _position;
        public InputActionReference Rotation => _rotation;
        public InputActionReference Scale => _scale;
    }
}