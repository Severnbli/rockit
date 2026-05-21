using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Configs
{
    public sealed class CoinsConfig : ScriptableObjectAutoInstaller<CoinsConfig>
    {
        [SerializeField] private int _coinsPerCollectedCoin = 1;
        
        public int CoinsPerCollectedCoin => _coinsPerCollectedCoin;
    }
}