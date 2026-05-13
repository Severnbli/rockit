using _Project.Scripts.Modules.Zenject;
using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Types;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Configs
{
    public sealed class GlitchConfig : ScriptableObjectAutoInstaller<GlitchConfig>
    {
        [SerializeField] private GlitchSettings _fallbackSettings;
        [SerializeField] private GlitchStep[] _steps;
        
        public GlitchSettings FallbackSettings => _fallbackSettings;
        public GlitchStep[] Steps => _steps;
    }
}