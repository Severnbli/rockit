using _Project.Scripts.Modules.Zenject;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Scripts.Runtime.Features.Input.Configs
{
    public class PlayerInputConfig : ScriptableObjectAutoInstaller<PlayerInputConfig>
    {
        [SerializeField] private InputActionReference _walk;
        
        public InputActionReference Walk => _walk;
    }
}