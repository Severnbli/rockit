using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Configs
{
    public class LayersConfig : ScriptableObjectAutoInstaller<LayersConfig>
    {
        [SerializeField] private LayerMask _groundLayer;
        
        public LayerMask GroundLayer => _groundLayer;
    }
}