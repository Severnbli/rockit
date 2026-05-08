using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Shared.Configs
{
    public sealed class PhysicsSharedConfig : ScriptableObjectAutoInstaller<PhysicsSharedConfig>
    {
        [SerializeField] private float _initialGravityScale = 1f;
        
        public float InitialGravityScale => _initialGravityScale;
    }
}