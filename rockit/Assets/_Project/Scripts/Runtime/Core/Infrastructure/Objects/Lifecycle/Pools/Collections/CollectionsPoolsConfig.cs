using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections
{
    public sealed class CollectionsPoolsConfig : ScriptableObjectAutoInstaller<CollectionsPoolsConfig>
    {
        [SerializeField] private int _initCapacity = 20;
        
        public int InitCapacity => _initCapacity;
    }
}