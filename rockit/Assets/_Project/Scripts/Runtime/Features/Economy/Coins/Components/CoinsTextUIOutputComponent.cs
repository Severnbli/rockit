using System;
using Leopotam.EcsProto.Unity;
using TMPro;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct CoinsTextUIOutputComponent
    {
        public TextMeshProUGUI _text;
    }
}