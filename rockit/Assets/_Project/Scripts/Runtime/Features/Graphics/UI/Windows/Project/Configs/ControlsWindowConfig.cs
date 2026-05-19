using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Project.Configs
{
    public sealed class ControlsWindowConfig : ScriptableObjectAutoInstaller<ControlsWindowConfig>
    {
        [SerializeField] private float _duration = 5f;
        
        public float Duration => _duration;
    }
}