using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections
{
    public class CollectionsPoolsConfig : ScriptableObjectAutoInstaller<CollectionsPoolsConfig>
    {
        [SerializeField] private int _initSize;
        
        public int InitSize => _initSize;
    }
}