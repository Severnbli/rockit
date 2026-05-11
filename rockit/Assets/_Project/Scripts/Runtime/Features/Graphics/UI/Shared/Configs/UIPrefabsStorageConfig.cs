using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Configs
{
    public sealed class UIPrefabsStorageConfig : ScriptableObjectAutoInstaller<UIPrefabsStorageConfig>
    {
        [SerializeField] private GameObject _levelButton;
        [SerializeField] private GameObject _filledStarImage;
        [SerializeField] private GameObject _emptyStarImage;
        
        public GameObject LevelButton => _levelButton;
        public GameObject FilledStarImage => _filledStarImage;
        public GameObject EmptyStarImage => _emptyStarImage;
    }
}