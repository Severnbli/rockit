using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Configs
{
    public sealed class UIPrefabsStorageConfig : ScriptableObjectAutoInstaller<UIPrefabsStorageConfig>
    {
        [SerializeField] private GameObject _levelButton;
        
        public GameObject LevelButton => _levelButton;
    }
}