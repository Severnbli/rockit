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
        [SerializeField] private float _stayDuration = 2f;
        [SerializeField] private float _transitionSpeed = 0.5f;
        
        public Color FallbackColor => _fallbackColor;
        public Color PosColor => _posColor;
        public Color RotColor => _rotColor;
        public Color ScaleColor => _scaleColor;
        public float StayDuration => _stayDuration;
        public float TransitionSpeed => _transitionSpeed;
    }
}