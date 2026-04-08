using _Project.Scripts.Modules.Zenject;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Scripts.Runtime.Features.Input.Configs
{
    public class PlayerInputConfig : ScriptableObjectAutoInstaller<PlayerInputConfig>
    {
        [SerializeField] private InputActionReference _walk;
        [SerializeField] private InputActionReference _jump;
        [SerializeField] private InputActionReference _dash;
        
        public InputActionReference Walk => _walk;
        public InputActionReference Jump => _jump;
        public InputActionReference Dash => _dash;
    }
}