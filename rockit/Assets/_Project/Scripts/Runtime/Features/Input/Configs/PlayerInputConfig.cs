using _Project.Scripts.Modules.Zenject;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Scripts.Runtime.Features.Input.Configs
{
    public sealed class PlayerInputConfig : ScriptableObjectAutoInstaller<PlayerInputConfig>
    {
        [SerializeField] private InputActionReference _walk;
        [SerializeField] private InputActionReference _jump;
        [SerializeField] private InputActionReference _dash;
        
        public InputAction Walk => _walk?.action;
        public InputAction Jump => _jump?.action;
        public InputAction Dash => _dash?.action;
    }
}