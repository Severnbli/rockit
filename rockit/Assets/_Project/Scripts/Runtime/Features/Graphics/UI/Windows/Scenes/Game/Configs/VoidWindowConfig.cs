using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Configs
{
    public sealed class VoidWindowConfig : ScriptableObjectAutoInstaller<VoidWindowConfig>
    {
        [SerializeField] private float _duration;
        
        public float Duration => _duration;
    }
}