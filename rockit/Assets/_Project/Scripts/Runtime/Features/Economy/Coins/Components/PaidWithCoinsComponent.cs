using System;
using Leopotam.EcsProto.Unity;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct PaidWithCoinsComponent
    {
        public int Amount;
    }
}