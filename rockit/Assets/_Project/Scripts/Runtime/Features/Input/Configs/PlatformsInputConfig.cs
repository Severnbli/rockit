using _Project.Scripts.Modules.Zenject;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Scripts.Runtime.Features.Input.Configs
{
    public class PlatformsInputConfig : ScriptableObjectAutoInstaller<PlatformsInputConfig>
    {
        [SerializeField] private InputActionReference _position;
        
        public InputActionReference Position => _position;
    }
}