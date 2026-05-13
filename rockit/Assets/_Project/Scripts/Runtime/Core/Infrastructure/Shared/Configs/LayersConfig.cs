using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Configs
{
    public sealed class LayersConfig : ScriptableObjectAutoInstaller<LayersConfig>
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private LayerMask _voidLayer;
        
        public LayerMask GroundLayer => _groundLayer;
        public LayerMask VoidLayer => _voidLayer;
    }
}