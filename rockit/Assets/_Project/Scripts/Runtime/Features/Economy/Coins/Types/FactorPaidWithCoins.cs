using System;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Types
{
    [Serializable]
    public class FactorPaidWithCoins : PaidWithCoins
    {
        [SerializeField] private float _factor;
        
        public float Factor => _factor;
    }
}