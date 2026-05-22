using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Configs
{
    public sealed class UIPrefabsStorageConfig : ScriptableObjectAutoInstaller<UIPrefabsStorageConfig>
    {
        [SerializeField] private GameObject _levelButton;
        [SerializeField] private GameObject _starIcon;
        [SerializeField] private GameObject _animatableStarIcon;
        [SerializeField] private GameObject _coinIcon;
        
        public GameObject LevelButton => _levelButton;
        public GameObject StarIcon => _starIcon;
        public GameObject AnimatableStarIcon => _animatableStarIcon;
        public GameObject CoinIcon => _coinIcon;
    }
}