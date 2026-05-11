using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Configs
{
    public sealed class PrefabsStorageConfig : ScriptableObjectAutoInstaller<PrefabsStorageConfig>
    {
        [SerializeField] private GameObject _levelButton;
        
        public GameObject LevelButton => _levelButton;
    }
}