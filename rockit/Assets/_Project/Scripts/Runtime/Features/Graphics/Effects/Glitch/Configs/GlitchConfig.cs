using _Project.Scripts.Modules.Zenject;
using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Types;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Configs
{
    public sealed class GlitchConfig : ScriptableObjectAutoInstaller<GlitchConfig>
    {
        [SerializeField] private GlitchSettings _defaultSettings;
        [SerializeField] private GlitchPhase[] _phases;
        
        public GlitchSettings DefaultSettings => _defaultSettings;
        public GlitchPhase[] Phases => _phases;
    }
}