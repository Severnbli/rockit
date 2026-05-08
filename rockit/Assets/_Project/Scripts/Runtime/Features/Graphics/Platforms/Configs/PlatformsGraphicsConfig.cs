using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Platforms.Configs
{
    public sealed class PlatformsGraphicsConfig : ScriptableObjectAutoInstaller<PlatformsGraphicsConfig>
    {
        [SerializeField] private Color _fallbackColor = Color.white;
        [SerializeField] private Color _posColor = Color.aquamarine;
        [SerializeField] private Color _rotColor = Color.gold;
        [SerializeField] private Color _scaleColor = Color.softRed;
        
        public Color FallbackColor => _fallbackColor;
        public Color PosColor => _posColor;
        public Color RotColor => _rotColor;
        public Color ScaleColor => _scaleColor;
    }
}