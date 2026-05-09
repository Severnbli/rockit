using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Shared.Configs
{
    public sealed class ColorConfig : ScriptableObjectAutoInstaller<ColorConfig>
    {
        [SerializeField] private float _colorChangeTolerance = 0.01f;
        
        public float ColorChangeTolerance => _colorChangeTolerance;
    }
}